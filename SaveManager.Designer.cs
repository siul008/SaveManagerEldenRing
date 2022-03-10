
namespace SaveManagerEldenRing
{
    partial class SaveManager
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveLocationButton = new System.Windows.Forms.Button();
            this.createSaveButton = new System.Windows.Forms.Button();
            this.deleteSaveButton = new System.Windows.Forms.Button();
            this.saveList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.saveList)).BeginInit();
            this.SuspendLayout();
            // 
            // saveLocationButton
            // 
            this.saveLocationButton.Location = new System.Drawing.Point(533, 12);
            this.saveLocationButton.Name = "saveLocationButton";
            this.saveLocationButton.Size = new System.Drawing.Size(116, 23);
            this.saveLocationButton.TabIndex = 0;
            this.saveLocationButton.Text = "Save Location";
            this.saveLocationButton.UseVisualStyleBackColor = true;
            this.saveLocationButton.Click += new System.EventHandler(this.saveLocationButton_Click);
            // 
            // createSaveButton
            // 
            this.createSaveButton.Enabled = false;
            this.createSaveButton.Location = new System.Drawing.Point(12, 415);
            this.createSaveButton.Name = "createSaveButton";
            this.createSaveButton.Size = new System.Drawing.Size(173, 23);
            this.createSaveButton.TabIndex = 1;
            this.createSaveButton.Text = "Create Save...";
            this.createSaveButton.UseVisualStyleBackColor = true;
            this.createSaveButton.Click += new System.EventHandler(this.createSaveButton_Click);
            // 
            // deleteSaveButton
            // 
            this.deleteSaveButton.Location = new System.Drawing.Point(191, 415);
            this.deleteSaveButton.Name = "deleteSaveButton";
            this.deleteSaveButton.Size = new System.Drawing.Size(130, 23);
            this.deleteSaveButton.TabIndex = 3;
            this.deleteSaveButton.Text = "Delete Save";
            this.deleteSaveButton.UseVisualStyleBackColor = true;
            this.deleteSaveButton.Click += new System.EventHandler(this.deleteSaveButton_Click);
            // 
            // saveList
            // 
            this.saveList.AllowUserToAddRows = false;
            this.saveList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.saveList.Location = new System.Drawing.Point(12, 227);
            this.saveList.Name = "saveList";
            this.saveList.Size = new System.Drawing.Size(309, 182);
            this.saveList.TabIndex = 4;
            this.saveList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.saveList_KeyDown);
            // 
            // SaveManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveList);
            this.Controls.Add(this.deleteSaveButton);
            this.Controls.Add(this.createSaveButton);
            this.Controls.Add(this.saveLocationButton);
            this.Name = "SaveManager";
            this.Text = "SaveManager";
            this.Load += new System.EventHandler(this.SaveManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.saveList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveLocationButton;
        private System.Windows.Forms.Button createSaveButton;
        private System.Windows.Forms.Button deleteSaveButton;
        private System.Windows.Forms.DataGridView saveList;
    }
}

