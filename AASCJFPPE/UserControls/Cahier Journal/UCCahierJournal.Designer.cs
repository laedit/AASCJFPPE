namespace AASCJFPPE.UserControls.Cahier_Journal
{
    partial class UCCahierJournal
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlJour = new System.Windows.Forms.Panel();
            this.lblJour = new System.Windows.Forms.Label();
            this.pnlPeriodeNom = new System.Windows.Forms.Panel();
            this.lblPEPrenomNom = new System.Windows.Forms.Label();
            this.lblPeriode = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlJour.SuspendLayout();
            this.pnlPeriodeNom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.pnlJour);
            this.pnlHeader.Controls.Add(this.pnlPeriodeNom);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1180, 102);
            this.pnlHeader.TabIndex = 5;
            // 
            // pnlJour
            // 
            this.pnlJour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlJour.Controls.Add(this.lblJour);
            this.pnlJour.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlJour.Location = new System.Drawing.Point(0, 50);
            this.pnlJour.Name = "pnlJour";
            this.pnlJour.Size = new System.Drawing.Size(1178, 50);
            this.pnlJour.TabIndex = 6;
            // 
            // lblJour
            // 
            this.lblJour.AutoSize = true;
            this.lblJour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJour.Location = new System.Drawing.Point(412, 16);
            this.lblJour.Name = "lblJour";
            this.lblJour.Size = new System.Drawing.Size(50, 16);
            this.lblJour.TabIndex = 0;
            this.lblJour.Text = "Jour : ";
            // 
            // pnlPeriodeNom
            // 
            this.pnlPeriodeNom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPeriodeNom.Controls.Add(this.lblPEPrenomNom);
            this.pnlPeriodeNom.Controls.Add(this.lblPeriode);
            this.pnlPeriodeNom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPeriodeNom.Location = new System.Drawing.Point(0, 0);
            this.pnlPeriodeNom.Name = "pnlPeriodeNom";
            this.pnlPeriodeNom.Size = new System.Drawing.Size(1178, 50);
            this.pnlPeriodeNom.TabIndex = 5;
            // 
            // lblPEPrenomNom
            // 
            this.lblPEPrenomNom.AutoSize = true;
            this.lblPEPrenomNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPEPrenomNom.Location = new System.Drawing.Point(918, 16);
            this.lblPEPrenomNom.Name = "lblPEPrenomNom";
            this.lblPEPrenomNom.Size = new System.Drawing.Size(60, 16);
            this.lblPEPrenomNom.TabIndex = 1;
            this.lblPEPrenomNom.Text = "P. NOM";
            // 
            // lblPeriode
            // 
            this.lblPeriode.AutoSize = true;
            this.lblPeriode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriode.Location = new System.Drawing.Point(412, 16);
            this.lblPeriode.Name = "lblPeriode";
            this.lblPeriode.Size = new System.Drawing.Size(75, 16);
            this.lblPeriode.TabIndex = 0;
            this.lblPeriode.Text = "Période : ";
            // 
            // UCCahierJournal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.pnlHeader);
            this.Name = "UCCahierJournal";
            this.Size = new System.Drawing.Size(1180, 754);
            this.Resize += new System.EventHandler(this.UCCahierJournal_Resize);
            this.pnlHeader.ResumeLayout(false);
            this.pnlJour.ResumeLayout(false);
            this.pnlJour.PerformLayout();
            this.pnlPeriodeNom.ResumeLayout(false);
            this.pnlPeriodeNom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        protected System.Windows.Forms.Panel pnlJour;
        protected System.Windows.Forms.Label lblJour;
        protected System.Windows.Forms.Panel pnlPeriodeNom;
        protected System.Windows.Forms.Label lblPeriode;
        protected System.Windows.Forms.Label lblPEPrenomNom;

    }
}
