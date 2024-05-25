namespace Bankautomat
{
    partial class WillkommenForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WillkommenForm));
            this.buttonSubmitWillkommenForm = new System.Windows.Forms.Button();
            this.panelLogoWillkommenForm = new System.Windows.Forms.Panel();
            this.labelLogoWillkommenForm = new System.Windows.Forms.Label();
            this.labelGrüsseWillkommenForm = new System.Windows.Forms.Label();
            this.textBoxIBANWillkommenForm = new System.Windows.Forms.TextBox();
            this.labelMussFormWillkommen = new System.Windows.Forms.Label();
            this.buttonAdminWillkommenFOrm = new System.Windows.Forms.Button();
            this.panelLogoWillkommenForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSubmitWillkommenForm
            // 
            this.buttonSubmitWillkommenForm.BackColor = System.Drawing.Color.Gold;
            this.buttonSubmitWillkommenForm.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.buttonSubmitWillkommenForm, "buttonSubmitWillkommenForm");
            this.buttonSubmitWillkommenForm.ForeColor = System.Drawing.Color.RoyalBlue;
            this.buttonSubmitWillkommenForm.Name = "buttonSubmitWillkommenForm";
            this.buttonSubmitWillkommenForm.UseVisualStyleBackColor = false;
            this.buttonSubmitWillkommenForm.Click += new System.EventHandler(this.buttonSubmitWillkommenForm_Click);
            // 
            // panelLogoWillkommenForm
            // 
            this.panelLogoWillkommenForm.BackColor = System.Drawing.Color.Gold;
            this.panelLogoWillkommenForm.Controls.Add(this.labelLogoWillkommenForm);
            this.panelLogoWillkommenForm.ForeColor = System.Drawing.Color.OliveDrab;
            resources.ApplyResources(this.panelLogoWillkommenForm, "panelLogoWillkommenForm");
            this.panelLogoWillkommenForm.Name = "panelLogoWillkommenForm";
            // 
            // labelLogoWillkommenForm
            // 
            resources.ApplyResources(this.labelLogoWillkommenForm, "labelLogoWillkommenForm");
            this.labelLogoWillkommenForm.BackColor = System.Drawing.Color.Gold;
            this.labelLogoWillkommenForm.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelLogoWillkommenForm.Name = "labelLogoWillkommenForm";
            // 
            // labelGrüsseWillkommenForm
            // 
            resources.ApplyResources(this.labelGrüsseWillkommenForm, "labelGrüsseWillkommenForm");
            this.labelGrüsseWillkommenForm.ForeColor = System.Drawing.Color.Gold;
            this.labelGrüsseWillkommenForm.Name = "labelGrüsseWillkommenForm";
            // 
            // textBoxIBANWillkommenForm
            // 
            resources.ApplyResources(this.textBoxIBANWillkommenForm, "textBoxIBANWillkommenForm");
            this.textBoxIBANWillkommenForm.Name = "textBoxIBANWillkommenForm";
            // 
            // labelMussFormWillkommen
            // 
            resources.ApplyResources(this.labelMussFormWillkommen, "labelMussFormWillkommen");
            this.labelMussFormWillkommen.ForeColor = System.Drawing.Color.Gold;
            this.labelMussFormWillkommen.Name = "labelMussFormWillkommen";
            // 
            // buttonAdminWillkommenFOrm
            // 
            this.buttonAdminWillkommenFOrm.BackColor = System.Drawing.Color.Gold;
            this.buttonAdminWillkommenFOrm.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.buttonAdminWillkommenFOrm, "buttonAdminWillkommenFOrm");
            this.buttonAdminWillkommenFOrm.ForeColor = System.Drawing.Color.RoyalBlue;
            this.buttonAdminWillkommenFOrm.Image = global::Bankautomat.Properties.Resources.Github_Octicons_Passkey_fill_16_48;
            this.buttonAdminWillkommenFOrm.Name = "buttonAdminWillkommenFOrm";
            this.buttonAdminWillkommenFOrm.UseVisualStyleBackColor = false;
            this.buttonAdminWillkommenFOrm.Click += new System.EventHandler(this.buttonAdminWillkommenFOrm_Click);
            // 
            // WillkommenForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.Controls.Add(this.buttonAdminWillkommenFOrm);
            this.Controls.Add(this.labelMussFormWillkommen);
            this.Controls.Add(this.textBoxIBANWillkommenForm);
            this.Controls.Add(this.labelGrüsseWillkommenForm);
            this.Controls.Add(this.panelLogoWillkommenForm);
            this.Controls.Add(this.buttonSubmitWillkommenForm);
            this.ForeColor = System.Drawing.Color.Orange;
            this.Name = "WillkommenForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WillkommenForm_FormClosed);
            this.Load += new System.EventHandler(this.WillkommenForm_Load);
            this.panelLogoWillkommenForm.ResumeLayout(false);
            this.panelLogoWillkommenForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSubmitWillkommenForm;
        private System.Windows.Forms.Panel panelLogoWillkommenForm;
        private System.Windows.Forms.Label labelLogoWillkommenForm;
        private System.Windows.Forms.Label labelGrüsseWillkommenForm;
        private System.Windows.Forms.TextBox textBoxIBANWillkommenForm;
        private System.Windows.Forms.Label labelMussFormWillkommen;
        private System.Windows.Forms.Button buttonAdminWillkommenFOrm;
    }
}

