namespace AASCJFPPE.UserControls.Cahier_Journal
{
    partial class UCCahierJournalModification
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
            this.components = new System.ComponentModel.Container();
            this.dtpDateDebut = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFin = new System.Windows.Forms.DateTimePicker();
            this.dtpDateJour = new System.Windows.Forms.DateTimePicker();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnAjouterSeance = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnDeleteLastSeance = new System.Windows.Forms.Button();
            this.pnlJour.SuspendLayout();
            this.pnlPeriodeNom.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlJour
            // 
            this.pnlJour.Controls.Add(this.dtpDateJour);
            this.pnlJour.Controls.SetChildIndex(this.dtpDateJour, 0);
            this.pnlJour.Controls.SetChildIndex(this.lblJour, 0);
            // 
            // pnlPeriodeNom
            // 
            this.pnlPeriodeNom.Controls.Add(this.dtpDateFin);
            this.pnlPeriodeNom.Controls.Add(this.dtpDateDebut);
            this.pnlPeriodeNom.Controls.SetChildIndex(this.lblPEPrenomNom, 0);
            this.pnlPeriodeNom.Controls.SetChildIndex(this.dtpDateDebut, 0);
            this.pnlPeriodeNom.Controls.SetChildIndex(this.lblPeriode, 0);
            this.pnlPeriodeNom.Controls.SetChildIndex(this.dtpDateFin, 0);
            // 
            // dtpDateDebut
            // 
            this.dtpDateDebut.Location = new System.Drawing.Point(494, 13);
            this.dtpDateDebut.Name = "dtpDateDebut";
            this.dtpDateDebut.Size = new System.Drawing.Size(200, 20);
            this.dtpDateDebut.TabIndex = 2;
            // 
            // dtpDateFin
            // 
            this.dtpDateFin.Location = new System.Drawing.Point(700, 12);
            this.dtpDateFin.Name = "dtpDateFin";
            this.dtpDateFin.Size = new System.Drawing.Size(200, 20);
            this.dtpDateFin.TabIndex = 3;
            // 
            // dtpDateJour
            // 
            this.dtpDateJour.Location = new System.Drawing.Point(465, 16);
            this.dtpDateJour.Name = "dtpDateJour";
            this.dtpDateJour.Size = new System.Drawing.Size(200, 20);
            this.dtpDateJour.TabIndex = 1;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnDeleteLastSeance);
            this.pnlFooter.Controls.Add(this.btnAjouterSeance);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 707);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1180, 47);
            this.pnlFooter.TabIndex = 7;
            // 
            // btnAjouterSeance
            // 
            this.btnAjouterSeance.Image = global::AASCJFPPE.Properties.Resources.add;
            this.btnAjouterSeance.Location = new System.Drawing.Point(13, 3);
            this.btnAjouterSeance.Name = "btnAjouterSeance";
            this.btnAjouterSeance.Size = new System.Drawing.Size(40, 40);
            this.btnAjouterSeance.TabIndex = 0;
            this.toolTip.SetToolTip(this.btnAjouterSeance, "Ajouter une séance");
            this.btnAjouterSeance.UseVisualStyleBackColor = true;
            this.btnAjouterSeance.Click += new System.EventHandler(this.btnAjouterSeance_Click);
            // 
            // btnDeleteLastSeance
            // 
            this.btnDeleteLastSeance.Image = global::AASCJFPPE.Properties.Resources.delete;
            this.btnDeleteLastSeance.Location = new System.Drawing.Point(59, 3);
            this.btnDeleteLastSeance.Name = "btnDeleteLastSeance";
            this.btnDeleteLastSeance.Size = new System.Drawing.Size(40, 40);
            this.btnDeleteLastSeance.TabIndex = 1;
            this.toolTip.SetToolTip(this.btnDeleteLastSeance, "Supprimer la dernière séance");
            this.btnDeleteLastSeance.UseVisualStyleBackColor = true;
            this.btnDeleteLastSeance.Click += new System.EventHandler(this.btnDeleteLastSeance_Click);
            // 
            // UCCahierJournalModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFooter);
            this.Name = "UCCahierJournalModification";
            this.Resize += new System.EventHandler(this.UCCahierJournalModification_Resize);
            this.Controls.SetChildIndex(this.pnlFooter, 0);
            this.pnlJour.ResumeLayout(false);
            this.pnlJour.PerformLayout();
            this.pnlPeriodeNom.ResumeLayout(false);
            this.pnlPeriodeNom.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDateDebut;
        private System.Windows.Forms.DateTimePicker dtpDateFin;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnAjouterSeance;
        public System.Windows.Forms.DateTimePicker dtpDateJour;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnDeleteLastSeance;
    }
}
