using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveManagerEldenRing
{   
    public partial class SaveManager : Form
    {
        public string saveLocationPath;
        BindingList<SaveFile> list;
        string folderPath;
        readonly string dataPath = @"C:\Users\" + Environment.UserName + @"\Documents\EldenRingBackup\ListData\";
        readonly string dataPathTxt = @"C:\Users\" + Environment.UserName + @"\Documents\EldenRingBackup\ListData\json.txt";
        readonly string saveLocationPathTxt = @"C:\Users\" + Environment.UserName + @"\Documents\EldenRingBackup\ListData\saveLocation.txt";
        SaveFile currentSaveQuitout;
        public bool saveQuitEnabled;
        WriteMemory writerMemory;
        bool cancelWorkDead = false;
        bool cancelWorkMenu = false;
        bool cancelWorkRestart = false;

        private static BackgroundWorker deadWorker;
        private static BackgroundWorker menuWorker;
        private static BackgroundWorker restartWorker;


        public SaveManager()
        {
            InitializeComponent();
            folderPath = @"C:\Users\"+Environment.UserName+ @"\Documents\EldenRingBackup\";
        }
        private void SaveManager_Load(object sender, EventArgs e)
        {           
            if(!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (!Directory.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
            }
            if (!File.Exists(dataPathTxt))
            {
                StreamWriter sw = File.CreateText(dataPathTxt);
                sw.Close();
            }
            if (!File.Exists(saveLocationPathTxt))
            {
                StreamWriter sw = File.CreateText(saveLocationPathTxt);
                sw.Close();
            }
            else
            {
                saveLocationPath = File.ReadAllText(saveLocationPathTxt);
            }
            list = new BindingList<SaveFile>();
            if(JsonConvert.DeserializeObject(File.ReadAllText(dataPathTxt)) != null)
            {
                list = JsonConvert.DeserializeObject<BindingList<SaveFile>>(File.ReadAllText(dataPathTxt));
            }
            saveQuitEnabled = false;

            /* WORKERS */
            deadWorker = new BackgroundWorker();
            deadWorker.WorkerSupportsCancellation = true;
            deadWorker.DoWork += CheckForDeath;
            deadWorker.RunWorkerCompleted += DeadWorkerLoopCompleted;

            menuWorker = new BackgroundWorker();
            menuWorker.WorkerSupportsCancellation = true;
            menuWorker.DoWork += CheckIfInMenu;
            menuWorker.RunWorkerCompleted += MenuWorkerLoopCompleted;

            restartWorker = new BackgroundWorker();
            restartWorker.WorkerSupportsCancellation = true;
            restartWorker.DoWork += CheckForRestart;
            restartWorker.RunWorkerCompleted += RestartWorkerLoopCompleted;

            UpdateUi();
            GetSaveList();

        }
        public void UpdateUi()
        {
            if(!String.IsNullOrWhiteSpace(saveLocationPath))
            {
                createSaveButton.Enabled = true;               
                File.WriteAllText(saveLocationPathTxt, saveLocationPath);
            }
        }

        public void GetSaveList()
        {
            saveList.DataSource = list;
            saveList.Columns[0].Visible = false;
            saveList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public BindingList<SaveFile> GetList()
        {
            return list;
        }
        public void AddToList(string mSaveName)
        {
            DateTime Date = DateTime.Now;
            SaveFile save = new SaveFile(mSaveName,(Date.Year * Date.Month * Date.Day * Date.Millisecond));
          list.Add(save);
            string json = JsonConvert.SerializeObject(list);
            string _folderpath = folderPath + save.id;
            CopyDirectory(saveLocationPath, _folderpath);
            File.WriteAllText(dataPathTxt, json);
        }

        private void createSaveButton_Click(object sender, EventArgs e)
        {
            var createSaveForm = new CreateSave(this);
            createSaveForm.ShowDialog();
        } 
        private void saveLocationButton_Click(object sender, EventArgs e)
        {
            var browseSaveForm = new BrowseSaveForm(this);
            browseSaveForm.ShowDialog();
        }

        private void deleteSaveButton_Click(object sender, EventArgs e)
        {
            DeleteCell();
        }

        private void saveList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteCell();
            }
        }
        public void DeleteCell()
        {
            if (saveList.CurrentCell != null)
            {
                int rowIndex = saveList.CurrentCell.RowIndex;
                DataGridViewRow selectedRow = saveList.Rows[rowIndex];
                string savename = Convert.ToString(selectedRow.Cells["SaveName"].Value);

                if (MessageBox.Show("Are you sure you want to delete [" + savename + "] ?", "Delete Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Directory.Delete(folderPath + Convert.ToString(selectedRow.Cells["id"].Value), true);
                    saveList.Rows.RemoveAt(rowIndex);
                    string json = JsonConvert.SerializeObject(list);
                    File.WriteAllText(dataPathTxt, json);
                }
            }
            else
            {
                MessageBox.Show("Select a save first", "Can't delete");
            }
        } 
        public void CopyDirectory(string sourceDir, string destinationDir)
        {
            var dir = new DirectoryInfo(sourceDir);
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");
            }
            Directory.CreateDirectory(destinationDir);
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }
        }
        public void LoadDirectory (string deleteDir, string copyToDir)
        {
                var dir = new DirectoryInfo(deleteDir);
            if(!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");
            }

            foreach (FileInfo file in dir.GetFiles())
            {
                file.Delete();
            }
            CopyDirectory(copyToDir, deleteDir);
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            int rowIndex = saveList.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = saveList.Rows[rowIndex];
            string id = Convert.ToString(selectedRow.Cells["id"].Value);
            string savename = Convert.ToString(selectedRow.Cells["SaveName"].Value);
            if (MessageBox.Show("Are you sure you want to load [" + savename + "] ? Your current save file will be erased", "Load Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LoadDirectory(saveLocationPath, folderPath + id);
            }
        }

        private void quitoutCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateQuitUI();
            if(writerMemory == null)
            {
                writerMemory = new WriteMemory();
            }
        }

        private void UpdateQuitUI()
        {
            if (quitoutCheckBox.Checked == true)
            {
                quitoutButton.Enabled = true;
                saveQuitEnabled = true;
                if (currentSaveQuitout != null)
                {
                    forceQuitButton.Enabled = true;
                    quitoutSaveLabel.Visible = true;
                    deadWorker.RunWorkerAsync();
                }
            }
            else
            {
                currentSaveQuitout = null;
                quitoutButton.Enabled = false;
                quitoutSaveLabel.Visible = true;
                forceQuitButton.Enabled = false;
                saveQuitEnabled = false;
                quitoutSaveLabel.Visible = false;
                quitoutSaveLabel.Text = "No Save Loaded";
                cancelWorkDead = true;
            }
        }
        private void quitoutButton_Click(object sender, EventArgs e)
        {
            var quitoutSaveForm = new QuitoutSave(this);
            quitoutSaveForm.ShowDialog();
        }
        public void ChangeCurrentQuitoutSave(long id, string name)
        {
            currentSaveQuitout = new SaveFile(name, id);
            quitoutSaveLabel.Text = $"Current Save Loaded : {currentSaveQuitout.SaveName}";
            UpdateQuitUI();
        }

        private void forceQuitButton_Click(object sender, EventArgs e)
        {
            QuitAndLoad();
        }
        private void QuitAndLoad()
        {
            cancelWorkDead = true;
            Debug.Write("Quitté à " + DateTime.Now);
            writerMemory.Quitout();
            menuWorker.RunWorkerAsync();
        }
       
        static void DeadWorkerLoopCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                deadWorker.RunWorkerAsync();
            }
            else
            {
                Debug.WriteLine("Dead Cancelled");
            }
        }
        static void MenuWorkerLoopCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                menuWorker.RunWorkerAsync();
            }
            else
            {
                Debug.WriteLine("Menu Cancelled");
            }
        }
        static void RestartWorkerLoopCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                restartWorker.RunWorkerAsync();
            }
            else
            {
                Debug.WriteLine("Restart Cancelled");
            }
        }
        private void CheckIfInMenu(object sender, DoWorkEventArgs e)
        {  
            if(cancelWorkMenu == true)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                if (writerMemory.CheckIfInMenu() == true)
                {
                    Debug.Write("Dans le menu, load de la save " + DateTime.Now);
                    if (currentSaveQuitout != null)
                    {
                        Thread.Sleep(2000);
                        LoadDirectory(saveLocationPath, folderPath + currentSaveQuitout.id);
                        cancelWorkRestart = false;
                        cancelWorkMenu = true;
                        restartWorker.RunWorkerAsync();
                    }
                }
                else
                {
                    Debug.Write("Pas encore dans le menu " + DateTime.Now);
                }
            }         
        }
        private void CheckForDeath(object sender, DoWorkEventArgs e)
        {
            if (cancelWorkDead == true)
            {
                e.Cancel = true;
                return;
            }
            if (writerMemory.IsDead() == true)
            {
                QuitAndLoad();
            }
        }
        private void CheckForRestart(object sender, DoWorkEventArgs e)
        {
            if(cancelWorkRestart == true)
            {
                e.Cancel = true;
                return;
            }
            if ((writerMemory.CheckIfInMenu() == false) && writerMemory.IsDead() == false)
            {
                deadWorker.RunWorkerAsync();
                cancelWorkDead = false;
                cancelWorkRestart = true;
                cancelWorkMenu = false;
            }
        }
    }
}
