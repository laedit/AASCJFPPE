namespace AASCJFPPE
{
    partial class SettingsForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPEPrenom = new System.Windows.Forms.Label();
            this.txtPEPrenom = new System.Windows.Forms.TextBox();
            this.txtPENom = new System.Windows.Forms.TextBox();
            this.lblPENom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(117, 58);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Sauvegarder";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPEPrenom
            // 
            this.lblPEPrenom.AutoSize = true;
            this.lblPEPrenom.Location = new System.Drawing.Point(12, 9);
            this.lblPEPrenom.Name = "lblPEPrenom";
            this.lblPEPrenom.Size = new System.Drawing.Size(49, 13);
            this.lblPEPrenom.TabIndex = 1;
            this.lblPEPrenom.Text = "Prénom :";
            // 
            // txtPEPrenom
            // 
            this.txtPEPrenom.Location = new System.Drawing.Point(65, 6);
            this.txtPEPrenom.Name = "txtPEPrenom";
            this.txtPEPrenom.Size = new System.Drawing.Size(134, 20);
            this.txtPEPrenom.TabIndex = 2;
            // 
            // txtPENom
            // 
            this.txtPENom.Location = new System.Drawing.Point(65, 32);
            this.txtPENom.Name = "txtPENom";
            this.txtPENom.Size = new System.Drawing.Size(134, 20);
            this.txtPENom.TabIndex = 4;
            this.txtPENom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPENom_KeyDown);
            // 
            // lblPENom
            // 
            this.lblPENom.AutoSize = true;
            this.lblPENom.Location = new System.Drawing.Point(12, 35);
            this.lblPENom.Name = "lblPENom";
            this.lblPENom.Size = new System.Drawing.Size(35, 13);
            this.lblPENom.TabIndex = 3;
            this.lblPENom.Text = "Nom :";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 91);
            this.ControlBox = false;
            this.Controls.Add(this.txtPENom);
            this.Controls.Add(this.lblPENom);
            this.Controls.Add(this.txtPEPrenom);
            this.Controls.Add(this.lblPEPrenom);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paramètres";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPEPrenom;
        private System.Windows.Forms.TextBox txtPENom;
        private System.Windows.Forms.Label lblPENom;
        private System.Windows.Forms.TextBox txtPEPrenom;
    }
}