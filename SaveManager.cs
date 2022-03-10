using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public SaveManager()
        {
            InitializeComponent();
        }
        private void SaveManager_Load(object sender, EventArgs e)
        {
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
            list.Add(new SaveFile() { SaveName = saveName});
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
                    saveList.Rows.RemoveAt(rowIndex);
                }
            }
            else
            {
                MessageBox.Show("Select a save first", "Can't delete");
            }
        }
    }
}
