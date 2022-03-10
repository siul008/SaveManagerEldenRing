using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveManagerEldenRing
{   
    public partial class SaveManager : Form
    {
        public string saveLocationPath;
        BindingList<SaveFile> list;
        string folderPath;
        DateTime Date;

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
            list = new BindingList<SaveFile>();
            GetSaveList();
        }
        public void UpdateUi()
        {
            if(!String.IsNullOrWhiteSpace(saveLocationPath))
            {
                createSaveButton.Enabled = true;
            }
        }

        public void GetSaveList()
        {
            saveList.DataSource = list;
            saveList.Columns[0].Visible = false;
            saveList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public void AddToList(string saveName)
        {
          SaveFile save = new SaveFile() { SaveName = saveName};
          list.Add(save);
            CopyDirectory(saveLocationPath, folderPath + save.id);          
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
            DirectoryInfo[] dirs = dir.GetDirectories();
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
            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(deleteDir);
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
    }
}
