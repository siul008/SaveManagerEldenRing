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
    public partial class CreateSave : Form
    {
        SaveManager saveManager;
        public CreateSave(SaveManager _saveManager)
        {
            InitializeComponent();
            saveManager = _saveManager;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            saveManager.AddToList(saveNameTextBox.Text);
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveManager.AddToList(saveNameTextBox.Text);
                this.Close();
            }
        }

    }
}
