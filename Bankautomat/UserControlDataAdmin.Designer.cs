namespace Bankautomat
{
    partial class UserControlDataAdmin
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelHeader = new System.Windows.Forms.TableLayoutPanel();
            this.IbanAdmin = new System.Windows.Forms.Label();
            this.KundeNameAdmin = new System.Windows.Forms.Label();
            this.DatumUndZeitAdmin = new System.Windows.Forms.Label();
            this.AbhebungAdmin = new System.Windows.Forms.Label();
            this.WährungAdmin = new System.Windows.Forms.Label();
            this.tableLayoutPanelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelHeader
            // 
            this.tableLayoutPanelHeader.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelHeader.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanelHeader.ColumnCount = 5;
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelHeader.Controls.Add(this.IbanAdmin, 0, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.KundeNameAdmin, 0, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.DatumUndZeitAdmin, 0, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.AbhebungAdmin, 3, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.WährungAdmin, 4, 0);
            this.tableLayoutPanelHeader.ForeColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanelHeader.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelHeader.Name = "tableLayoutPanelHeader";
            this.tableLayoutPanelHeader.RowCount = 1;
            this.tableLayoutPanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHeader.Size = new System.Drawing.Size(1000, 35);
            this.tableLayoutPanelHeader.TabIndex = 16;
            // 
            // IbanAdmin
            // 
            this.IbanAdmin.AutoSize = true;
            this.IbanAdmin.BackColor = System.Drawing.Color.Azure;
            this.IbanAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IbanAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IbanAdmin.Location = new System.Drawing.Point(551, 3);
            this.IbanAdmin.Name = "IbanAdmin";
            this.IbanAdmin.Size = new System.Drawing.Size(190, 29);
            this.IbanAdmin.TabIndex = 2;
            this.IbanAdmin.Text = "Iban";
            this.IbanAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KundeNameAdmin
            // 
            this.KundeNameAdmin.AutoSize = true;
            this.KundeNameAdmin.BackColor = System.Drawing.Color.Azure;
            this.KundeNameAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KundeNameAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KundeNameAdmin.Location = new System.Drawing.Point(303, 3);
            this.KundeNameAdmin.Name = "KundeNameAdmin";
            this.KundeNameAdmin.Size = new System.Drawing.Size(239, 29);
            this.KundeNameAdmin.TabIndex = 1;
            this.KundeNameAdmin.Text = "Name";
            this.KundeNameAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DatumUndZeitAdmin
            // 
            this.DatumUndZeitAdmin.AutoSize = true;
            this.DatumUndZeitAdmin.BackColor = System.Drawing.Color.Azure;
            this.DatumUndZeitAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatumUndZeitAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatumUndZeitAdmin.Location = new System.Drawing.Point(6, 3);
            this.DatumUndZeitAdmin.Name = "DatumUndZeitAdmin";
            this.DatumUndZeitAdmin.Size = new System.Drawing.Size(288, 29);
            this.DatumUndZeitAdmin.TabIndex = 0;
            this.DatumUndZeitAdmin.Text = "Datum und Zeit";
            this.DatumUndZeitAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AbhebungAdmin
            // 
            this.AbhebungAdmin.AutoSize = true;
            this.AbhebungAdmin.BackColor = System.Drawing.Color.Azure;
            this.AbhebungAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AbhebungAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AbhebungAdmin.Location = new System.Drawing.Point(750, 3);
            this.AbhebungAdmin.Name = "AbhebungAdmin";
            this.AbhebungAdmin.Size = new System.Drawing.Size(141, 29);
            this.AbhebungAdmin.TabIndex = 3;
            this.AbhebungAdmin.Text = "Abhebung";
            this.AbhebungAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WährungAdmin
            // 
            this.WährungAdmin.AutoSize = true;
            this.WährungAdmin.BackColor = System.Drawing.Color.Azure;
            this.WährungAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WährungAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WährungAdmin.Location = new System.Drawing.Point(900, 3);
            this.WährungAdmin.Name = "WährungAdmin";
            this.WährungAdmin.Size = new System.Drawing.Size(94, 29);
            this.WährungAdmin.TabIndex = 4;
            this.WährungAdmin.Text = "$ € £";
            this.WährungAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControlDataAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelHeader);
            this.Name = "UserControlDataAdmin";
            this.Size = new System.Drawing.Size(1000, 35);
            this.tableLayoutPanelHeader.ResumeLayout(false);
            this.tableLayoutPanelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHeader;
        private System.Windows.Forms.Label IbanAdmin;
        private System.Windows.Forms.Label KundeNameAdmin;
        private System.Windows.Forms.Label DatumUndZeitAdmin;
        private System.Windows.Forms.Label AbhebungAdmin;
        private System.Windows.Forms.Label WährungAdmin;
    }
}
