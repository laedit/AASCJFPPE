namespace AASCJFPPE.UserControls.Cahier_Journal
{
    partial class UCCahierJournalVisualisation
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
            this.lblDataPeriode = new System.Windows.Forms.Label();
            this.lblDataJour = new System.Windows.Forms.Label();
            this.pnlJour.SuspendLayout();
            this.pnlPeriodeNom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlJour
            // 
            this.pnlJour.Controls.Add(this.lblDataJour);
            this.pnlJour.Controls.SetChildIndex(this.lblJour, 0);
            this.pnlJour.Controls.SetChildIndex(this.lblDataJour, 0);
            // 
            // pnlPeriodeNom
            // 
            this.pnlPeriodeNom.Controls.Add(this.lblDataPeriode);
            this.pnlPeriodeNom.Controls.SetChildIndex(this.lblDataPeriode, 0);
            this.pnlPeriodeNom.Controls.SetChildIndex(this.lblPeriode, 0);
            // 
            // lblDataPeriode
            // 
            this.lblDataPeriode.AutoSize = true;
            this.lblDataPeriode.Location = new System.Drawing.Point(485, 16);
            this.lblDataPeriode.Name = "lblDataPeriode";
            this.lblDataPeriode.Size = new System.Drawing.Size(35, 13);
            this.lblDataPeriode.TabIndex = 2;
            this.lblDataPeriode.Text = "label1";
            // 
            // lblDataJour
            // 
            this.lblDataJour.AutoSize = true;
            this.lblDataJour.Location = new System.Drawing.Point(468, 19);
            this.lblDataJour.Name = "lblDataJour";
            this.lblDataJour.Size = new System.Drawing.Size(35, 13);
            this.lblDataJour.TabIndex = 3;
            this.lblDataJour.Text = "label1";
            // 
            // UCCahierJournalVisualisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UCCahierJournalVisualisation";
            this.Resize += new System.EventHandler(this.UCCahierJournalVisualisation_Resize);
            this.pnlJour.ResumeLayout(false);
            this.pnlJour.PerformLayout();
            this.pnlPeriodeNom.ResumeLayout(false);
            this.pnlPeriodeNom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDataPeriode;
        private System.Windows.Forms.Label lblDataJour;
    }
}
