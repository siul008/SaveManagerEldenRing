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
    public partial class BrowseSaveForm : Form
    {
        SaveManager saveManager;
        FolderBrowserDialog fdlg;
        BindingList<SaveFile> list;
        public BrowseSaveForm(SaveManager _saveManager)
        {
            InitializeComponent();
            saveManager = _saveManager;
            pathLabel.Text = "Path : " + saveManager.saveLocationPath;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            fdlg = new FolderBrowserDialog();
            DialogResult result = fdlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                savePathEditBox.Text = fdlg.SelectedPath;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (savePathEditBox.Text.Contains("EldenRing") && (savePathEditBox.Text.Contains("Roaming")))
            {
                saveManager.saveLocationPath = savePathEditBox.Text;
                saveManager.UpdateUi();
                this.Close();
            }
            else
            {
                MessageBox.Show("Path is invalid");
            }
        }
    }
}
