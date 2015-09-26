namespace AASCJFPPE.UserControls
{
    partial class ListeEleves
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
            this.lblNiveau = new System.Windows.Forms.Label();
            this.cmbNiveau = new System.Windows.Forms.ComboBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.ucEleveList1 = new AASCJFPPE.UserControls.Liste_Eleves.UCEleveList();
            this.btnAddELeve = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNiveau
            // 
            this.lblNiveau.AutoSize = true;
            this.lblNiveau.Location = new System.Drawing.Point(4, 14);
            this.lblNiveau.Name = "lblNiveau";
            this.lblNiveau.Size = new System.Drawing.Size(41, 13);
            this.lblNiveau.TabIndex = 0;
            this.lblNiveau.Text = "Niveau";
            // 
            // cmbNiveau
            // 
            this.cmbNiveau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNiveau.FormattingEnabled = true;
            this.cmbNiveau.Location = new System.Drawing.Point(52, 14);
            this.cmbNiveau.Name = "cmbNiveau";
            this.cmbNiveau.Size = new System.Drawing.Size(121, 21);
            this.cmbNiveau.TabIndex = 1;
            this.cmbNiveau.SelectedIndexChanged += new System.EventHandler(this.cmbNiveau_SelectedIndexChanged);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnAddELeve);
            this.pnlHeader.Controls.Add(this.cmbNiveau);
            this.pnlHeader.Controls.Add(this.lblNiveau);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(864, 73);
            this.pnlHeader.TabIndex = 2;
            // 
            // ucEleveList1
            // 
            this.ucEleveList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEleveList1.Location = new System.Drawing.Point(0, 73);
            this.ucEleveList1.Name = "ucEleveList1";
            this.ucEleveList1.Size = new System.Drawing.Size(864, 627);
            this.ucEleveList1.TabIndex = 3;
            // 
            // btnAddELeve
            // 
            this.btnAddELeve.Image = global::AASCJFPPE.Properties.Resources.add;
            this.btnAddELeve.Location = new System.Drawing.Point(194, 14);
            this.btnAddELeve.Name = "btnAddELeve";
            this.btnAddELeve.Size = new System.Drawing.Size(40, 40);
            this.btnAddELeve.TabIndex = 4;
            this.btnAddELeve.UseVisualStyleBackColor = true;
            this.btnAddELeve.Click += new System.EventHandler(this.btnAddELeve_Click);
            // 
            // ListeEleves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucEleveList1);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ListeEleves";
            this.Size = new System.Drawing.Size(864, 700);
            this.Load += new System.EventHandler(this.ListeEleves_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNiveau;
        private System.Windows.Forms.ComboBox cmbNiveau;
        private System.Windows.Forms.Panel pnlHeader;
        private Liste_Eleves.UCEleveList ucEleveList1;
        private System.Windows.Forms.Button btnAddELeve;
    }
}
