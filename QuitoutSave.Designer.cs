
namespace SaveManagerEldenRing
{
    partial class QuitoutSave
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuitoutSave));
            this.quitoutSaveList = new System.Windows.Forms.DataGridView();
            this.informationQuitoutLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.quitoutSaveList)).BeginInit();
            this.SuspendLayout();
            // 
            // quitoutSaveList
            // 
            this.quitoutSaveList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.quitoutSaveList.Location = new System.Drawing.Point(13, 38);
            this.quitoutSaveList.Name = "quitoutSaveList";
            this.quitoutSaveList.Size = new System.Drawing.Size(260, 204);
            this.quitoutSaveList.TabIndex = 0;
            this.quitoutSaveList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.quitoutSaveList_CellContentClick);
            // 
            // informationQuitoutLabel
            // 
            this.informationQuitoutLabel.AutoSize = true;
            this.informationQuitoutLabel.Location = new System.Drawing.Point(12, 9);
            this.informationQuitoutLabel.MaximumSize = new System.Drawing.Size(250, 40);
            this.informationQuitoutLabel.Name = "informationQuitoutLabel";
            this.informationQuitoutLabel.Size = new System.Drawing.Size(243, 26);
            this.informationQuitoutLabel.TabIndex = 1;
            this.informationQuitoutLabel.Text = "Choose what save you want to automatically load on death / keybind";
            // 
            // QuitoutSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 254);
            this.Controls.Add(this.informationQuitoutLabel);
            this.Controls.Add(this.quitoutSaveList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuitoutSave";
            this.Text = "QuitoutSave";
            ((System.ComponentModel.ISupportInitialize)(this.quitoutSaveList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView quitoutSaveList;
        private System.Windows.Forms.Label informationQuitoutLabel;
    }
}