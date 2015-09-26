namespace AASCJFPPE.UserControls.Fiche_preparatoires
{
    partial class UCDidactiqueFPVisualisation
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
            this.lblConditions = new System.Windows.Forms.Label();
            this.lblPerformances = new System.Windows.Forms.Label();
            this.lblDispositifSocial = new System.Windows.Forms.Label();
            this.lblDuree = new System.Windows.Forms.Label();
            this.lblMaterielLieu = new System.Windows.Forms.Label();
            this.lblOrdre = new System.Windows.Forms.Label();
            this.pnlPerformances.SuspendLayout();
            this.pnlDispositifSocial.SuspendLayout();
            this.pnlDuree.SuspendLayout();
            this.pnlConditions.SuspendLayout();
            this.pnlMaterielLieu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPerformances
            // 
            this.pnlPerformances.Controls.Add(this.lblPerformances);
            // 
            // pnlDispositifSocial
            // 
            this.pnlDispositifSocial.Controls.Add(this.lblDispositifSocial);
            // 
            // pnlDuree
            // 
            this.pnlDuree.Controls.Add(this.lblDuree);
            // 
            // pnlConditions
            // 
            this.pnlConditions.Controls.Add(this.lblOrdre);
            this.pnlConditions.Controls.Add(this.lblConditions);
            // 
            // pnlMaterielLieu
            // 
            this.pnlMaterielLieu.Controls.Add(this.lblMaterielLieu);
            // 
            // lblConditions
            // 
            this.lblConditions.AutoSize = true;
            this.lblConditions.Location = new System.Drawing.Point(74, 20);
            this.lblConditions.Name = "lblConditions";
            this.lblConditions.Size = new System.Drawing.Size(55, 13);
            this.lblConditions.TabIndex = 0;
            this.lblConditions.Text = "conditions";
            // 
            // lblPerformances
            // 
            this.lblPerformances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPerformances.Location = new System.Drawing.Point(0, 0);
            this.lblPerformances.Name = "lblPerformances";
            this.lblPerformances.Padding = new System.Windows.Forms.Padding(2);
            this.lblPerformances.Size = new System.Drawing.Size(394, 57);
            this.lblPerformances.TabIndex = 1;
            this.lblPerformances.Text = "performances";
            // 
            // lblDispositifSocial
            // 
            this.lblDispositifSocial.AutoSize = true;
            this.lblDispositifSocial.Location = new System.Drawing.Point(30, 20);
            this.lblDispositifSocial.Name = "lblDispositifSocial";
            this.lblDispositifSocial.Size = new System.Drawing.Size(77, 13);
            this.lblDispositifSocial.TabIndex = 1;
            this.lblDispositifSocial.Text = "dispositif social";
            // 
            // lblDuree
            // 
            this.lblDuree.AutoSize = true;
            this.lblDuree.Location = new System.Drawing.Point(25, 20);
            this.lblDuree.Name = "lblDuree";
            this.lblDuree.Size = new System.Drawing.Size(34, 13);
            this.lblDuree.TabIndex = 1;
            this.lblDuree.Text = "durée";
            // 
            // lblMaterielLieu
            // 
            this.lblMaterielLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaterielLieu.Location = new System.Drawing.Point(0, 0);
            this.lblMaterielLieu.Name = "lblMaterielLieu";
            this.lblMaterielLieu.Padding = new System.Windows.Forms.Padding(2);
            this.lblMaterielLieu.Size = new System.Drawing.Size(178, 57);
            this.lblMaterielLieu.TabIndex = 1;
            this.lblMaterielLieu.Text = "matériel / lieu";
            // 
            // lblOrdre
            // 
            this.lblOrdre.AutoSize = true;
            this.lblOrdre.Location = new System.Drawing.Point(3, 20);
            this.lblOrdre.Name = "lblOrdre";
            this.lblOrdre.Size = new System.Drawing.Size(31, 13);
            this.lblOrdre.TabIndex = 1;
            this.lblOrdre.Text = "ordre";
            // 
            // UCDidactiqueFPVisualisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UCDidactiqueFPVisualisation";
            this.Resize += new System.EventHandler(this.UCDidactiqueCJVisualisation_Resize);
            this.pnlPerformances.ResumeLayout(false);
            this.pnlDispositifSocial.ResumeLayout(false);
            this.pnlDispositifSocial.PerformLayout();
            this.pnlDuree.ResumeLayout(false);
            this.pnlDuree.PerformLayout();
            this.pnlConditions.ResumeLayout(false);
            this.pnlConditions.PerformLayout();
            this.pnlMaterielLieu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblConditions;
        private System.Windows.Forms.Label lblPerformances;
        private System.Windows.Forms.Label lblDispositifSocial;
        private System.Windows.Forms.Label lblDuree;
        private System.Windows.Forms.Label lblMaterielLieu;
        private System.Windows.Forms.Label lblOrdre;
    }
}
