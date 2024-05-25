namespace Bankautomat
{
    partial class UserControlDataTableKunde
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public UserControlDataTableKunde()
        {
            InitializeComponent();
        }

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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelUserControl = new System.Windows.Forms.TableLayoutPanel();
            this.DatumUndZeitDaten = new System.Windows.Forms.Label();
            this.AbhebungDaten = new System.Windows.Forms.Label();
            this.WährungDaten = new System.Windows.Forms.Label();
            this.tableLayoutPanelUserControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelUserControl
            // 
            this.tableLayoutPanelUserControl.BackColor = System.Drawing.Color.Gold;
            this.tableLayoutPanelUserControl.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelUserControl.ColumnCount = 3;
            this.tableLayoutPanelUserControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelUserControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelUserControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelUserControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelUserControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelUserControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelUserControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelUserControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelUserControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelUserControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelUserControl.Controls.Add(this.DatumUndZeitDaten, 0, 0);
            this.tableLayoutPanelUserControl.Controls.Add(this.AbhebungDaten, 1, 0);
            this.tableLayoutPanelUserControl.Controls.Add(this.WährungDaten, 2, 0);
            this.tableLayoutPanelUserControl.Location = new System.Drawing.Point(0, -7);
            this.tableLayoutPanelUserControl.Name = "tableLayoutPanelUserControl";
            this.tableLayoutPanelUserControl.RowCount = 1;
            this.tableLayoutPanelUserControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelUserControl.Size = new System.Drawing.Size(773, 44);
            this.tableLayoutPanelUserControl.TabIndex = 15;
            // 
            // DatumUndZeitDaten
            // 
            this.DatumUndZeitDaten.AutoSize = true;
            this.DatumUndZeitDaten.BackColor = System.Drawing.Color.Transparent;
            this.DatumUndZeitDaten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatumUndZeitDaten.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatumUndZeitDaten.ForeColor = System.Drawing.Color.Crimson;
            this.DatumUndZeitDaten.Location = new System.Drawing.Point(4, 1);
            this.DatumUndZeitDaten.Name = "DatumUndZeitDaten";
            this.DatumUndZeitDaten.Size = new System.Drawing.Size(378, 42);
            this.DatumUndZeitDaten.TabIndex = 0;
            this.DatumUndZeitDaten.Text = "Datum und Zeit";
            this.DatumUndZeitDaten.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AbhebungDaten
            // 
            this.AbhebungDaten.BackColor = System.Drawing.Color.Transparent;
            this.AbhebungDaten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AbhebungDaten.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AbhebungDaten.ForeColor = System.Drawing.Color.Crimson;
            this.AbhebungDaten.Location = new System.Drawing.Point(389, 1);
            this.AbhebungDaten.Name = "AbhebungDaten";
            this.AbhebungDaten.Size = new System.Drawing.Size(263, 42);
            this.AbhebungDaten.TabIndex = 1;
            this.AbhebungDaten.Text = "Abhebung";
            this.AbhebungDaten.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WährungDaten
            // 
            this.WährungDaten.AutoSize = true;
            this.WährungDaten.BackColor = System.Drawing.Color.Transparent;
            this.WährungDaten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WährungDaten.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WährungDaten.ForeColor = System.Drawing.Color.Crimson;
            this.WährungDaten.Location = new System.Drawing.Point(659, 1);
            this.WährungDaten.Name = "WährungDaten";
            this.WährungDaten.Size = new System.Drawing.Size(110, 42);
            this.WährungDaten.TabIndex = 2;
            this.WährungDaten.Text = "Währung";
            this.WährungDaten.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControlDataTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelUserControl);
            this.Name = "UserControlDataTable";
            this.Size = new System.Drawing.Size(773, 30);
            this.tableLayoutPanelUserControl.ResumeLayout(false);
            this.tableLayoutPanelUserControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelUserControl;
        private System.Windows.Forms.Label WährungDaten;
        private System.Windows.Forms.Label AbhebungDaten;
        private System.Windows.Forms.Label DatumUndZeitDaten;
    }
}
