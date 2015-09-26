namespace AASCJFPPE.UserControls.Fiche_preparatoires
{
    partial class UCFichePreparatoireModification
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
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnDeleteLastSeance = new System.Windows.Forms.Button();
            this.btnAjouterSeance = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.pnlJour.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlJour
            // 
            this.pnlJour.Controls.Add(this.dtpDate);
            this.pnlJour.Controls.SetChildIndex(this.dtpDate, 0);
            this.pnlJour.Controls.SetChildIndex(this.lblJour, 0);
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
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(465, 16);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 1;
            // 
            // UCFichePreparatoireModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFooter);
            this.Name = "UCFichePreparatoireModification";
            this.Resize += new System.EventHandler(this.UCFichePreparatoireModification_Resize);
            this.Controls.SetChildIndex(this.pnlFooter, 0);
            this.pnlJour.ResumeLayout(false);
            this.pnlJour.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnAjouterSeance;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnDeleteLastSeance;
        public System.Windows.Forms.DateTimePicker dtpDate;
    }
}
