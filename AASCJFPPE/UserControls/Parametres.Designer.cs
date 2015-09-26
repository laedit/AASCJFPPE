namespace AASCJFPPE.UserControls
{
    partial class Parametres
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbNom = new System.Windows.Forms.GroupBox();
            this.txtPENom = new System.Windows.Forms.TextBox();
            this.lblPENom = new System.Windows.Forms.Label();
            this.txtPEPrenom = new System.Windows.Forms.TextBox();
            this.lblPEPrenom = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbDataBackup = new System.Windows.Forms.GroupBox();
            this.cbDBFrequency = new System.Windows.Forms.ComboBox();
            this.lblDBFrequency = new System.Windows.Forms.Label();
            this.gbDataRestore = new System.Windows.Forms.GroupBox();
            this.cmbDataRestore = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            this.gbNom.SuspendLayout();
            this.gbDataBackup.SuspendLayout();
            this.gbDataRestore.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNom
            // 
            this.gbNom.Controls.Add(this.txtPENom);
            this.gbNom.Controls.Add(this.lblPENom);
            this.gbNom.Controls.Add(this.txtPEPrenom);
            this.gbNom.Controls.Add(this.lblPEPrenom);
            this.gbNom.Location = new System.Drawing.Point(178, 23);
            this.gbNom.Name = "gbNom";
            this.gbNom.Size = new System.Drawing.Size(207, 85);
            this.gbNom.TabIndex = 34;
            this.gbNom.TabStop = false;
            this.gbNom.Text = "Nom";
            // 
            // txtPENom
            // 
            this.txtPENom.Location = new System.Drawing.Point(59, 45);
            this.txtPENom.Name = "txtPENom";
            this.txtPENom.Size = new System.Drawing.Size(134, 20);
            this.txtPENom.TabIndex = 9;
            // 
            // lblPENom
            // 
            this.lblPENom.AutoSize = true;
            this.lblPENom.Location = new System.Drawing.Point(6, 48);
            this.lblPENom.Name = "lblPENom";
            this.lblPENom.Size = new System.Drawing.Size(35, 13);
            this.lblPENom.TabIndex = 8;
            this.lblPENom.Text = "Nom :";
            // 
            // txtPEPrenom
            // 
            this.txtPEPrenom.Location = new System.Drawing.Point(59, 19);
            this.txtPEPrenom.Name = "txtPEPrenom";
            this.txtPEPrenom.Size = new System.Drawing.Size(134, 20);
            this.txtPEPrenom.TabIndex = 7;
            // 
            // lblPEPrenom
            // 
            this.lblPEPrenom.AutoSize = true;
            this.lblPEPrenom.Location = new System.Drawing.Point(6, 22);
            this.lblPEPrenom.Name = "lblPEPrenom";
            this.lblPEPrenom.Size = new System.Drawing.Size(49, 13);
            this.lblPEPrenom.TabIndex = 6;
            this.lblPEPrenom.Text = "Prénom :";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(303, 204);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Sauvegarder";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbDataBackup
            // 
            this.gbDataBackup.Controls.Add(this.cbDBFrequency);
            this.gbDataBackup.Controls.Add(this.lblDBFrequency);
            this.gbDataBackup.Location = new System.Drawing.Point(178, 129);
            this.gbDataBackup.Name = "gbDataBackup";
            this.gbDataBackup.Size = new System.Drawing.Size(207, 65);
            this.gbDataBackup.TabIndex = 35;
            this.gbDataBackup.TabStop = false;
            this.gbDataBackup.Text = "Sauvegarde des données";
            // 
            // cbDBFrequency
            // 
            this.cbDBFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDBFrequency.FormattingEnabled = true;
            this.cbDBFrequency.Items.AddRange(new object[] {
            "Jamais",
            "Journalière",
            "Hebdomaire",
            "Mensuelle"});
            this.cbDBFrequency.Location = new System.Drawing.Point(77, 20);
            this.cbDBFrequency.Name = "cbDBFrequency";
            this.cbDBFrequency.Size = new System.Drawing.Size(121, 21);
            this.cbDBFrequency.TabIndex = 7;
            // 
            // lblDBFrequency
            // 
            this.lblDBFrequency.AutoSize = true;
            this.lblDBFrequency.Location = new System.Drawing.Point(6, 22);
            this.lblDBFrequency.Name = "lblDBFrequency";
            this.lblDBFrequency.Size = new System.Drawing.Size(64, 13);
            this.lblDBFrequency.TabIndex = 6;
            this.lblDBFrequency.Text = "Fréquence :";
            // 
            // gbDataRestore
            // 
            this.gbDataRestore.Controls.Add(this.cmbDataRestore);
            this.gbDataRestore.Controls.Add(this.lblDate);
            this.gbDataRestore.Location = new System.Drawing.Point(178, 251);
            this.gbDataRestore.Name = "gbDataRestore";
            this.gbDataRestore.Size = new System.Drawing.Size(207, 65);
            this.gbDataRestore.TabIndex = 36;
            this.gbDataRestore.TabStop = false;
            this.gbDataRestore.Text = "Restauration des données";
            // 
            // cmbDataRestore
            // 
            this.cmbDataRestore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataRestore.FormattingEnabled = true;
            this.cmbDataRestore.Location = new System.Drawing.Point(48, 20);
            this.cmbDataRestore.Name = "cmbDataRestore";
            this.cmbDataRestore.Size = new System.Drawing.Size(150, 21);
            this.cmbDataRestore.TabIndex = 7;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(6, 22);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Date :";
            // 
            // btnRestore
            // 
            this.btnRestore.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRestore.Location = new System.Drawing.Point(303, 325);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(82, 23);
            this.btnRestore.TabIndex = 37;
            this.btnRestore.Text = "Restaurer";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // Parametres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.gbDataRestore);
            this.Controls.Add(this.gbDataBackup);
            this.Controls.Add(this.gbNom);
            this.Controls.Add(this.btnSave);
            this.Name = "Parametres";
            this.Size = new System.Drawing.Size(864, 700);
            this.VisibleChanged += new System.EventHandler(this.Parametres_VisibleChanged);
            this.Resize += new System.EventHandler(this.Parametres_Resize);
            this.gbNom.ResumeLayout(false);
            this.gbNom.PerformLayout();
            this.gbDataBackup.ResumeLayout(false);
            this.gbDataBackup.PerformLayout();
            this.gbDataRestore.ResumeLayout(false);
            this.gbDataRestore.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNom;
        private System.Windows.Forms.TextBox txtPENom;
        private System.Windows.Forms.Label lblPENom;
        private System.Windows.Forms.TextBox txtPEPrenom;
        private System.Windows.Forms.Label lblPEPrenom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbDataBackup;
        private System.Windows.Forms.ComboBox cbDBFrequency;
        private System.Windows.Forms.Label lblDBFrequency;
        private System.Windows.Forms.GroupBox gbDataRestore;
        private System.Windows.Forms.ComboBox cmbDataRestore;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnRestore;
    }
}
