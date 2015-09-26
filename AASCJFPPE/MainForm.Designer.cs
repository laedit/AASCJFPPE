namespace AASCJFPPE
{
    partial class MainForm
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
            this.tcCategories = new System.Windows.Forms.TabControl();
            this.tbpCahierJournal = new System.Windows.Forms.TabPage();
            this.ucFicheCahierJournal = new AASCJFPPE.UserControls.Cahier_Journal.UCFicheCahierJournal();
            this.tbpFichesPreparatoires = new System.Windows.Forms.TabPage();
            this.ucFicheFP = new AASCJFPPE.UserControls.Fiche_preparatoires.UCFicheFP();
            this.tbpEmploiTemps = new System.Windows.Forms.TabPage();
            this.tbpListeEleves = new System.Windows.Forms.TabPage();
            this.ucListeEleves = new AASCJFPPE.UserControls.ListeEleves();
            this.tbpInformationsComplementaires = new System.Windows.Forms.TabPage();
            this.informationcomplementaire = new AASCJFPPE.UserControls.Informationcomplementaire();
            this.tbpParametres = new System.Windows.Forms.TabPage();
            this.parametres = new AASCJFPPE.UserControls.Parametres();
            this.tbpAPropos = new System.Windows.Forms.TabPage();
            this.aPropos = new AASCJFPPE.UserControls.APropos();
            this.tcCategories.SuspendLayout();
            this.tbpCahierJournal.SuspendLayout();
            this.tbpFichesPreparatoires.SuspendLayout();
            this.tbpListeEleves.SuspendLayout();
            this.tbpInformationsComplementaires.SuspendLayout();
            this.tbpParametres.SuspendLayout();
            this.tbpAPropos.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcCategories
            // 
            this.tcCategories.Controls.Add(this.tbpCahierJournal);
            this.tcCategories.Controls.Add(this.tbpFichesPreparatoires);
            this.tcCategories.Controls.Add(this.tbpEmploiTemps);
            this.tcCategories.Controls.Add(this.tbpListeEleves);
            this.tcCategories.Controls.Add(this.tbpInformationsComplementaires);
            this.tcCategories.Controls.Add(this.tbpParametres);
            this.tcCategories.Controls.Add(this.tbpAPropos);
            this.tcCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCategories.Location = new System.Drawing.Point(0, 0);
            this.tcCategories.Multiline = true;
            this.tcCategories.Name = "tcCategories";
            this.tcCategories.SelectedIndex = 0;
            this.tcCategories.Size = new System.Drawing.Size(1214, 672);
            this.tcCategories.TabIndex = 0;
            // 
            // tbpCahierJournal
            // 
            this.tbpCahierJournal.Controls.Add(this.ucFicheCahierJournal);
            this.tbpCahierJournal.Location = new System.Drawing.Point(4, 22);
            this.tbpCahierJournal.Name = "tbpCahierJournal";
            this.tbpCahierJournal.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCahierJournal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbpCahierJournal.Size = new System.Drawing.Size(1206, 646);
            this.tbpCahierJournal.TabIndex = 0;
            this.tbpCahierJournal.Text = "Cahier Journal";
            this.tbpCahierJournal.UseVisualStyleBackColor = true;
            // 
            // ucFicheCahierJournal
            // 
            this.ucFicheCahierJournal.AutoScroll = true;
            this.ucFicheCahierJournal.AutoSize = true;
            this.ucFicheCahierJournal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFicheCahierJournal.Location = new System.Drawing.Point(3, 3);
            this.ucFicheCahierJournal.Name = "ucFicheCahierJournal";
            this.ucFicheCahierJournal.Size = new System.Drawing.Size(1200, 640);
            this.ucFicheCahierJournal.TabIndex = 0;
            // 
            // tbpFichesPreparatoires
            // 
            this.tbpFichesPreparatoires.Controls.Add(this.ucFicheFP);
            this.tbpFichesPreparatoires.Location = new System.Drawing.Point(4, 22);
            this.tbpFichesPreparatoires.Name = "tbpFichesPreparatoires";
            this.tbpFichesPreparatoires.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFichesPreparatoires.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbpFichesPreparatoires.Size = new System.Drawing.Size(1206, 646);
            this.tbpFichesPreparatoires.TabIndex = 1;
            this.tbpFichesPreparatoires.Text = "Fiches Préparatoires";
            this.tbpFichesPreparatoires.UseVisualStyleBackColor = true;
            // 
            // ucFicheFP
            // 
            this.ucFicheFP.AutoScroll = true;
            this.ucFicheFP.AutoSize = true;
            this.ucFicheFP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFicheFP.Location = new System.Drawing.Point(3, 3);
            this.ucFicheFP.Name = "ucFicheFP";
            //this.ucFicheFP.performancesRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ucFicheFP.Size = new System.Drawing.Size(1200, 640);
            this.ucFicheFP.TabIndex = 0;
            // 
            // tbpEmploiTemps
            // 
            this.tbpEmploiTemps.Location = new System.Drawing.Point(4, 22);
            this.tbpEmploiTemps.Name = "tbpEmploiTemps";
            this.tbpEmploiTemps.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbpEmploiTemps.Size = new System.Drawing.Size(1206, 646);
            this.tbpEmploiTemps.TabIndex = 2;
            this.tbpEmploiTemps.Text = "Emploi du temps";
            this.tbpEmploiTemps.UseVisualStyleBackColor = true;
            // 
            // tbpListeEleves
            // 
            this.tbpListeEleves.Controls.Add(this.ucListeEleves);
            this.tbpListeEleves.Location = new System.Drawing.Point(4, 22);
            this.tbpListeEleves.Name = "tbpListeEleves";
            this.tbpListeEleves.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbpListeEleves.Size = new System.Drawing.Size(1206, 646);
            this.tbpListeEleves.TabIndex = 3;
            this.tbpListeEleves.Text = "Liste des élèves";
            this.tbpListeEleves.UseVisualStyleBackColor = true;
            // 
            // ucListeEleves
            // 
            this.ucListeEleves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucListeEleves.Location = new System.Drawing.Point(0, 0);
            this.ucListeEleves.Name = "ucListeEleves";
            this.ucListeEleves.Size = new System.Drawing.Size(1206, 646);
            this.ucListeEleves.TabIndex = 0;
            // 
            // tbpInformationsComplementaires
            // 
            this.tbpInformationsComplementaires.Controls.Add(this.informationcomplementaire);
            this.tbpInformationsComplementaires.Location = new System.Drawing.Point(4, 22);
            this.tbpInformationsComplementaires.Name = "tbpInformationsComplementaires";
            this.tbpInformationsComplementaires.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbpInformationsComplementaires.Size = new System.Drawing.Size(1206, 646);
            this.tbpInformationsComplementaires.TabIndex = 4;
            this.tbpInformationsComplementaires.Text = "Informations complémentaires";
            this.tbpInformationsComplementaires.UseVisualStyleBackColor = true;
            // 
            // informationcomplementaire
            // 
            this.informationcomplementaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.informationcomplementaire.EleveId = ((long)(0));
            this.informationcomplementaire.Location = new System.Drawing.Point(0, 0);
            this.informationcomplementaire.Name = "informationcomplementaire";
            this.informationcomplementaire.Size = new System.Drawing.Size(1206, 646);
            this.informationcomplementaire.TabIndex = 0;
            // 
            // tbpParametres
            // 
            this.tbpParametres.Controls.Add(this.parametres);
            this.tbpParametres.Location = new System.Drawing.Point(4, 22);
            this.tbpParametres.Name = "tbpParametres";
            this.tbpParametres.Size = new System.Drawing.Size(1206, 646);
            this.tbpParametres.TabIndex = 5;
            this.tbpParametres.Text = "Paramètres";
            this.tbpParametres.UseVisualStyleBackColor = true;
            // 
            // parametres
            // 
            this.parametres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parametres.Location = new System.Drawing.Point(0, 0);
            this.parametres.Name = "parametres";
            this.parametres.Size = new System.Drawing.Size(1206, 646);
            this.parametres.TabIndex = 0;
            // 
            // tbpAPropos
            // 
            this.tbpAPropos.Controls.Add(this.aPropos);
            this.tbpAPropos.Location = new System.Drawing.Point(4, 22);
            this.tbpAPropos.Name = "tbpAPropos";
            this.tbpAPropos.Size = new System.Drawing.Size(1206, 646);
            this.tbpAPropos.TabIndex = 6;
            this.tbpAPropos.Text = "A propos";
            this.tbpAPropos.UseVisualStyleBackColor = true;
            // 
            // aPropos
            // 
            this.aPropos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aPropos.Location = new System.Drawing.Point(0, 0);
            this.aPropos.Name = "aPropos";
            this.aPropos.Size = new System.Drawing.Size(1206, 646);
            this.aPropos.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 672);
            this.Controls.Add(this.tcCategories);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Alpha] Application d\'Aide à la Saisie du Cahier Journal et des Fiches Préparatoi" +
    "res pour les Professeurs des Ecoles";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tcCategories.ResumeLayout(false);
            this.tbpCahierJournal.ResumeLayout(false);
            this.tbpCahierJournal.PerformLayout();
            this.tbpFichesPreparatoires.ResumeLayout(false);
            this.tbpFichesPreparatoires.PerformLayout();
            this.tbpListeEleves.ResumeLayout(false);
            this.tbpInformationsComplementaires.ResumeLayout(false);
            this.tbpParametres.ResumeLayout(false);
            this.tbpAPropos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcCategories;
        private System.Windows.Forms.TabPage tbpCahierJournal;
        private System.Windows.Forms.TabPage tbpFichesPreparatoires;
        private System.Windows.Forms.TabPage tbpEmploiTemps;
        private System.Windows.Forms.TabPage tbpListeEleves;
        private System.Windows.Forms.TabPage tbpInformationsComplementaires;
        private System.Windows.Forms.TabPage tbpParametres;
        private System.Windows.Forms.TabPage tbpAPropos;
        private UserControls.APropos aPropos;
        private UserControls.Cahier_Journal.UCFicheCahierJournal ucFicheCahierJournal;
        private UserControls.Informationcomplementaire informationcomplementaire;
        private UserControls.Parametres parametres;
        private UserControls.ListeEleves ucListeEleves;
        private UserControls.Fiche_preparatoires.UCFicheFP ucFicheFP;
    }
}

