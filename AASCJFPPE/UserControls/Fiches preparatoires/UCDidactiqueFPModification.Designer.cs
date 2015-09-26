namespace AASCJFPPE.UserControls.Fiche_preparatoires
{
    partial class UCDidactiqueFPModification
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
            this.cmbConditions = new System.Windows.Forms.ComboBox();
            this.txtPerformances = new System.Windows.Forms.TextBox();
            this.cmbDispositifSocial = new System.Windows.Forms.ComboBox();
            this.nudDuree = new System.Windows.Forms.NumericUpDown();
            this.txtMaterielLieu = new System.Windows.Forms.TextBox();
            this.nudOrdre = new System.Windows.Forms.NumericUpDown();
            this.pnlPerformances.SuspendLayout();
            this.pnlDispositifSocial.SuspendLayout();
            this.pnlDuree.SuspendLayout();
            this.pnlConditions.SuspendLayout();
            this.pnlMaterielLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOrdre)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPerformances
            // 
            this.pnlPerformances.Controls.Add(this.txtPerformances);
            // 
            // pnlDispositifSocial
            // 
            this.pnlDispositifSocial.Controls.Add(this.cmbDispositifSocial);
            // 
            // pnlDuree
            // 
            this.pnlDuree.Controls.Add(this.nudDuree);
            // 
            // pnlConditions
            // 
            this.pnlConditions.Controls.Add(this.nudOrdre);
            this.pnlConditions.Controls.Add(this.cmbConditions);
            // 
            // pnlMaterielLieu
            // 
            this.pnlMaterielLieu.Controls.Add(this.txtMaterielLieu);
            // 
            // cmbConditions
            // 
            this.cmbConditions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConditions.FormattingEnabled = true;
            this.cmbConditions.Location = new System.Drawing.Point(62, 16);
            this.cmbConditions.Name = "cmbConditions";
            this.cmbConditions.Size = new System.Drawing.Size(248, 21);
            this.cmbConditions.TabIndex = 0;
            // 
            // txtPerformances
            // 
            this.txtPerformances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPerformances.Location = new System.Drawing.Point(6, 5);
            this.txtPerformances.Multiline = true;
            this.txtPerformances.Name = "txtPerformances";
            this.txtPerformances.Size = new System.Drawing.Size(383, 47);
            this.txtPerformances.TabIndex = 0;
            // 
            // cmbDispositifSocial
            // 
            this.cmbDispositifSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDispositifSocial.FormattingEnabled = true;
            this.cmbDispositifSocial.Location = new System.Drawing.Point(8, 16);
            this.cmbDispositifSocial.Name = "cmbDispositifSocial";
            this.cmbDispositifSocial.Size = new System.Drawing.Size(121, 21);
            this.cmbDispositifSocial.TabIndex = 0;
            // 
            // nudDuree
            // 
            this.nudDuree.Location = new System.Drawing.Point(6, 16);
            this.nudDuree.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nudDuree.Name = "nudDuree";
            this.nudDuree.Size = new System.Drawing.Size(73, 20);
            this.nudDuree.TabIndex = 0;
            // 
            // txtMaterielLieu
            // 
            this.txtMaterielLieu.Location = new System.Drawing.Point(5, 3);
            this.txtMaterielLieu.Multiline = true;
            this.txtMaterielLieu.Name = "txtMaterielLieu";
            this.txtMaterielLieu.Size = new System.Drawing.Size(169, 46);
            this.txtMaterielLieu.TabIndex = 0;
            // 
            // nudOrdre
            // 
            this.nudOrdre.Location = new System.Drawing.Point(8, 17);
            this.nudOrdre.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nudOrdre.Name = "nudOrdre";
            this.nudOrdre.Size = new System.Drawing.Size(32, 20);
            this.nudOrdre.TabIndex = 1;
            // 
            // UCDidactiqueFPModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UCDidactiqueFPModification";
            this.pnlPerformances.ResumeLayout(false);
            this.pnlPerformances.PerformLayout();
            this.pnlDispositifSocial.ResumeLayout(false);
            this.pnlDuree.ResumeLayout(false);
            this.pnlConditions.ResumeLayout(false);
            this.pnlMaterielLieu.ResumeLayout(false);
            this.pnlMaterielLieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOrdre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbConditions;
        private System.Windows.Forms.TextBox txtPerformances;
        private System.Windows.Forms.ComboBox cmbDispositifSocial;
        private System.Windows.Forms.NumericUpDown nudDuree;
        private System.Windows.Forms.TextBox txtMaterielLieu;
        private System.Windows.Forms.NumericUpDown nudOrdre;

    }
}
