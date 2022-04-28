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
    public partial class QuitoutSave : Form
    {
        SaveManager saveManagerForm;
        BindingList<SaveFile> mList;
        public QuitoutSave(SaveManager _saveManager)
        {
            InitializeComponent();
            saveManagerForm = _saveManager;
            mList = saveManagerForm.GetList();
            quitoutSaveList.DataSource = mList;
            quitoutSaveList.Columns[0].Visible = false;
            quitoutSaveList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void quitoutSaveList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = quitoutSaveList.Rows[e.RowIndex];
            string savename = Convert.ToString(selectedRow.Cells["SaveName"].Value);
            long id = (long)selectedRow.Cells["id"].Value;
            if (MessageBox.Show("Are you sure you want to load [" + savename + "] on death ? Your current save file will be erased", "Load Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                saveManagerForm.ChangeCurrentQuitoutSave(id, savename);
                this.Close();
            }
        }
    }
}
