namespace AASCJFPPE.UserControls.Cahier_Journal
{
    partial class UCSeanceCJModification
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
            this.cmbDiscipline = new System.Windows.Forms.ComboBox();
            this.cmbDomainActivite = new System.Windows.Forms.ComboBox();
            this.nudNumero = new System.Windows.Forms.NumericUpDown();
            this.txtObjectifs = new System.Windows.Forms.TextBox();
            this.txtTrancheHoraire = new System.Windows.Forms.TextBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnAjouterDidactique = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnDeleteLastDidactique = new System.Windows.Forms.Button();
            this.pnlInformations.SuspendLayout();
            this.pnlDisciplineEtDomaineActivite.SuspendLayout();
            this.pnlTrancheHoraire.SuspendLayout();
            this.pnlNumeroSeance.SuspendLayout();
            this.pnlObjectifs.SuspendLayout();
            this.pnlDidactiques.SuspendLayout();
            this.pnlDidactiquesHeader.SuspendLayout();
            this.pnlDeroulement.SuspendLayout();
            this.pnlDispositifSocial.SuspendLayout();
            this.pnlDuree.SuspendLayout();
            this.pnlOrdre.SuspendLayout();
            this.pnlRealise.SuspendLayout();
            this.pnlPhasesApprentissage.SuspendLayout();
            this.pnlMaterielLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumero)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInformations
            // 
            this.pnlInformations.Size = new System.Drawing.Size(1176, 92);
            // 
            // pnlDisciplineEtDomaineActivite
            // 
            this.pnlDisciplineEtDomaineActivite.Controls.Add(this.cmbDomainActivite);
            this.pnlDisciplineEtDomaineActivite.Controls.Add(this.cmbDiscipline);
            this.pnlDisciplineEtDomaineActivite.Size = new System.Drawing.Size(686, 92);
            this.pnlDisciplineEtDomaineActivite.Resize += new System.EventHandler(this.pnlDisciplineEtDomaineActivite_Resize);
            this.pnlDisciplineEtDomaineActivite.Controls.SetChildIndex(this.lblDisciplineEtDomaineActivite, 0);
            this.pnlDisciplineEtDomaineActivite.Controls.SetChildIndex(this.cmbDiscipline, 0);
            this.pnlDisciplineEtDomaineActivite.Controls.SetChildIndex(this.cmbDomainActivite, 0);
            // 
            // lblDisciplineEtDomaineActivite
            // 
            this.lblDisciplineEtDomaineActivite.Location = new System.Drawing.Point(215, 15);
            // 
            // pnlTrancheHoraire
            // 
            this.pnlTrancheHoraire.Controls.Add(this.txtTrancheHoraire);
            this.pnlTrancheHoraire.Controls.SetChildIndex(this.lblTrancheHoraire, 0);
            this.pnlTrancheHoraire.Controls.SetChildIndex(this.txtTrancheHoraire, 0);
            // 
            // pnlNumeroSeance
            // 
            this.pnlNumeroSeance.Controls.Add(this.nudNumero);
            this.pnlNumeroSeance.Location = new System.Drawing.Point(942, 0);
            this.pnlNumeroSeance.Controls.SetChildIndex(this.lblNumeroSeance, 0);
            this.pnlNumeroSeance.Controls.SetChildIndex(this.nudNumero, 0);
            // 
            // pnlObjectifs
            // 
            this.pnlObjectifs.Controls.Add(this.txtObjectifs);
            this.pnlObjectifs.Size = new System.Drawing.Size(1176, 77);
            this.pnlObjectifs.Controls.SetChildIndex(this.lblObjectifs, 0);
            this.pnlObjectifs.Controls.SetChildIndex(this.txtObjectifs, 0);
            // 
            // pnlDidactiques
            // 
            this.pnlDidactiques.AutoSize = true;
            this.pnlDidactiques.Controls.Add(this.pnlFooter);
            this.pnlDidactiques.Size = new System.Drawing.Size(1176, 527);
            this.pnlDidactiques.Controls.SetChildIndex(this.pnlFooter, 0);
            this.pnlDidactiques.Controls.SetChildIndex(this.pnlDidactiquesHeader, 0);
            // 
            // pnlDidactiquesHeader
            // 
            this.pnlDidactiquesHeader.Size = new System.Drawing.Size(1174, 57);
            // 
            // pnlDeroulement
            // 
            this.pnlDeroulement.Size = new System.Drawing.Size(340, 57);
            // 
            // lblDeroulement
            // 
            this.lblDeroulement.Location = new System.Drawing.Point(122, 18);
            // 
            // pnlDispositifSocial
            // 
            this.pnlDispositifSocial.Location = new System.Drawing.Point(770, 0);
            // 
            // pnlDuree
            // 
            this.pnlDuree.Location = new System.Drawing.Point(908, 0);
            // 
            // pnlMaterielLieu
            // 
            this.pnlMaterielLieu.Location = new System.Drawing.Point(994, 0);
            // 
            // cmbDiscipline
            // 
            this.cmbDiscipline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiscipline.FormattingEnabled = true;
            this.cmbDiscipline.Location = new System.Drawing.Point(14, 43);
            this.cmbDiscipline.Name = "cmbDiscipline";
            this.cmbDiscipline.Size = new System.Drawing.Size(204, 21);
            this.cmbDiscipline.TabIndex = 3;
            this.cmbDiscipline.SelectedIndexChanged += new System.EventHandler(this.cmbDiscipline_SelectedIndexChanged);
            // 
            // cmbDomainActivite
            // 
            this.cmbDomainActivite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDomainActivite.Enabled = false;
            this.cmbDomainActivite.FormattingEnabled = true;
            this.cmbDomainActivite.Location = new System.Drawing.Point(288, 43);
            this.cmbDomainActivite.Name = "cmbDomainActivite";
            this.cmbDomainActivite.Size = new System.Drawing.Size(188, 21);
            this.cmbDomainActivite.TabIndex = 4;
            // 
            // nudNumero
            // 
            this.nudNumero.Location = new System.Drawing.Point(99, 15);
            this.nudNumero.Name = "nudNumero";
            this.nudNumero.Size = new System.Drawing.Size(35, 20);
            this.nudNumero.TabIndex = 3;
            // 
            // txtObjectifs
            // 
            this.txtObjectifs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObjectifs.Location = new System.Drawing.Point(181, 14);
            this.txtObjectifs.Multiline = true;
            this.txtObjectifs.Name = "txtObjectifs";
            this.txtObjectifs.Size = new System.Drawing.Size(985, 56);
            this.txtObjectifs.TabIndex = 2;
            // 
            // txtTrancheHoraire
            // 
            this.txtTrancheHoraire.Location = new System.Drawing.Point(139, 15);
            this.txtTrancheHoraire.MaxLength = 20;
            this.txtTrancheHoraire.Name = "txtTrancheHoraire";
            this.txtTrancheHoraire.Size = new System.Drawing.Size(97, 20);
            this.txtTrancheHoraire.TabIndex = 3;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnDeleteLastDidactique);
            this.pnlFooter.Controls.Add(this.btnAjouterDidactique);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 480);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1174, 45);
            this.pnlFooter.TabIndex = 4;
            // 
            // btnAjouterDidactique
            // 
            this.btnAjouterDidactique.Image = global::AASCJFPPE.Properties.Resources.add;
            this.btnAjouterDidactique.Location = new System.Drawing.Point(7, 2);
            this.btnAjouterDidactique.Name = "btnAjouterDidactique";
            this.btnAjouterDidactique.Size = new System.Drawing.Size(40, 40);
            this.btnAjouterDidactique.TabIndex = 0;
            this.toolTip.SetToolTip(this.btnAjouterDidactique, "Ajouter une didactique");
            this.btnAjouterDidactique.UseVisualStyleBackColor = true;
            this.btnAjouterDidactique.Click += new System.EventHandler(this.btnAjouterDidactique_Click);
            // 
            // btnDeleteLastDidactique
            // 
            this.btnDeleteLastDidactique.Image = global::AASCJFPPE.Properties.Resources.delete;
            this.btnDeleteLastDidactique.Location = new System.Drawing.Point(53, 2);
            this.btnDeleteLastDidactique.Name = "btnDeleteLastDidactique";
            this.btnDeleteLastDidactique.Size = new System.Drawing.Size(40, 40);
            this.btnDeleteLastDidactique.TabIndex = 1;
            this.toolTip.SetToolTip(this.btnDeleteLastDidactique, "Supprimer la dernière didactique");
            this.btnDeleteLastDidactique.UseVisualStyleBackColor = true;
            this.btnDeleteLastDidactique.Click += new System.EventHandler(this.btnDeleteLastDidactique_Click);
            // 
            // UCSeanceCJModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Name = "UCSeanceCJModification";
            this.pnlInformations.ResumeLayout(false);
            this.pnlDisciplineEtDomaineActivite.ResumeLayout(false);
            this.pnlDisciplineEtDomaineActivite.PerformLayout();
            this.pnlTrancheHoraire.ResumeLayout(false);
            this.pnlTrancheHoraire.PerformLayout();
            this.pnlNumeroSeance.ResumeLayout(false);
            this.pnlNumeroSeance.PerformLayout();
            this.pnlObjectifs.ResumeLayout(false);
            this.pnlObjectifs.PerformLayout();
            this.pnlDidactiques.ResumeLayout(false);
            this.pnlDidactiquesHeader.ResumeLayout(false);
            this.pnlDeroulement.ResumeLayout(false);
            this.pnlDeroulement.PerformLayout();
            this.pnlDispositifSocial.ResumeLayout(false);
            this.pnlDispositifSocial.PerformLayout();
            this.pnlDuree.ResumeLayout(false);
            this.pnlDuree.PerformLayout();
            this.pnlOrdre.ResumeLayout(false);
            this.pnlOrdre.PerformLayout();
            this.pnlRealise.ResumeLayout(false);
            this.pnlRealise.PerformLayout();
            this.pnlPhasesApprentissage.ResumeLayout(false);
            this.pnlPhasesApprentissage.PerformLayout();
            this.pnlMaterielLieu.ResumeLayout(false);
            this.pnlMaterielLieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumero)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDiscipline;
        private System.Windows.Forms.ComboBox cmbDomainActivite;
        private System.Windows.Forms.NumericUpDown nudNumero;
        private System.Windows.Forms.TextBox txtObjectifs;
        private System.Windows.Forms.TextBox txtTrancheHoraire;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnAjouterDidactique;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnDeleteLastDidactique;

    }
}
