using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bankautomat
{
    public partial class BanknotenEingebungAdminForm : Form
    {
        public DatenBankZugriff bankZugriff = new DatenBankZugriff();
        private List<WährungDatei> währungDateis = new List<WährungDatei>();
        private List<BanknoteNennwert> banknoteNennwerts = new List<BanknoteNennwert>();
        private List<BanknoteNennwert> banknoteNennwertsWährung = new List<BanknoteNennwert>();
        private Dictionary<int, int> banknoteNennwertCount = new Dictionary<int, int>();
        public BanknotenEingebungAdminForm()
        {
            InitializeComponent();
        }
        private void WährungDatenNehmer()
        {
            string connectionString = $"Data Source={bankZugriff.serverInstance};Initial Catalog={bankZugriff.dataBaseName};User ID={bankZugriff.userName};Password={bankZugriff.password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM WaehrungDaten";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var währung = new WährungDatei();
                            währung.Id = Convert.ToInt32(reader["id"]);
                            währung.Abkürzung = reader["abkuerzung"].ToString().Trim();
                            währung.Bezeichnung = reader["bezeichnung"].ToString();
                            währung.Umrechnungsfaktor = Convert.ToDecimal(reader["umrechnungsfaktor"]);
                            währungDateis.Add(währung);
                        }
                    }
                }
            }
        }
        private void BankNoteNennwertDatenNehmer()
        {
            string connectionString = $"Data Source={bankZugriff.serverInstance};Initial Catalog={bankZugriff.dataBaseName};User ID={bankZugriff.userName};Password={bankZugriff.password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM BanknoteNennwert";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var banknoteNennwert = new BanknoteNennwert();
                            banknoteNennwert.Id = (int)(reader["id"]);
                            banknoteNennwert.Anzahl = (int)reader["anzahl"];
                            banknoteNennwert.Nennwert = (int)reader["nennwert"];
                            banknoteNennwert.Währung_Id = (int)reader["IDWaehrungDaten"];
                            banknoteNennwerts.Add(banknoteNennwert);
                        }
                    }
                }
            }
        }
        private void BankNoteNennwertDatenSetter()
        {
            string connectionString = $"Data Source={bankZugriff.serverInstance};Initial Catalog={bankZugriff.dataBaseName};User ID={bankZugriff.userName};Password={bankZugriff.password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (var banknote in banknoteNennwertsWährung)
                {
                    string query = "UPDATE BanknoteNennwert \r\nSET anzahl = @anzahl \r\nWHERE id = @id;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", banknote.Id);
                        if (banknoteNennwertCount.ContainsKey(banknote.Nennwert))
                        {
                            int anzahlTemp = banknoteNennwertCount[banknote.Nennwert];
                            command.Parameters.Add("@anzahl", SqlDbType.Int).Value = anzahlTemp;

                        }
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        private void BankNoteSetter(int WährungID)
        {
            banknoteNennwertCount.Clear(); 
            int tempTag = 101;
            for (int i = 0; i < 6; i++)
            {
                banknoteNennwertsWährung = banknoteNennwerts.Where(b => b.Währung_Id == WährungID).ToList();
                string tempNameLabel = $"label{tempTag}BanknoteAdminForm";
                string tempNameTextBox = $"textBox{tempTag}BanknoteNehmerAdminForm";
                Label tempLabel = this.Controls.Find(tempNameLabel, true).FirstOrDefault() as Label;
                TextBox tempTextBox = this.Controls.Find(tempNameTextBox, true).FirstOrDefault() as TextBox;
                tempLabel.Text = $"{banknoteNennwertsWährung[i].Nennwert}";
                if (tempTextBox != null) { tempTextBox.Text = ""; }
                banknoteNennwertCount.Add(banknoteNennwertsWährung[i].Nennwert, banknoteNennwertsWährung[i].Anzahl);
                tempTag++;
            }
        }
        private void BanknotenEingebungAdminForm_Load(object sender, EventArgs e)
        {
            WährungDatenNehmer();
            BankNoteNennwertDatenNehmer();
            BankNoteSetter(1);

            var währung1id = währungDateis.FirstOrDefault();
            StripMenuWährungBanknotenAdminForm.Text = $"{währung1id.Abkürzung} {währung1id.Bezeichnung}";
            StripMenuWährungBanknotenAdminForm.Tag = währung1id.Id;
            foreach (var währung in währungDateis.Where(w => w.Id != 1))
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Name = $"ToolStripMenuItem{währung.Bezeichnung}";
                menuItem.Text = $"{währung.Abkürzung} {währung.Bezeichnung}";
                menuItem.Tag = währung.Id;

                menuItem.Click += WährungTauschEventAdminForm;
                StripMenuWährungBanknotenAdminForm.DropDownItems.Add(menuItem);
            }

            textBox101BanknoteNehmerAdminForm.Focus();
            this.AcceptButton = buttonEingebungAdminForm;
        }
        private void WährungTauschEventAdminForm(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem gedrücktTemp)
            {
                string formText = StripMenuWährungBanknotenAdminForm.Text;
                int formTag = (int)StripMenuWährungBanknotenAdminForm.Tag;

                StripMenuWährungBanknotenAdminForm.Text = gedrücktTemp.Text;
                StripMenuWährungBanknotenAdminForm.Tag = gedrücktTemp.Tag;
                gedrücktTemp.Text = formText;
                gedrücktTemp.Tag = formTag;

                int idWährungGewählt = (int)StripMenuWährungBanknotenAdminForm.Tag;

                var währungGewählt = währungDateis.FirstOrDefault(w => w.Id == idWährungGewählt);
                BankNoteSetter(idWährungGewählt);
            }
        }
        private void buttonEingebungAdminForm_Click(object sender, EventArgs e)
        {
            int tempTag = 101;
            for (int i = 0; i < 6; i++)
            {
                int anzahl = 0;
                string tempNameLabel = $"label{tempTag}BanknoteAdminForm";
                string tempNameTextBox = $"textBox{tempTag}BanknoteNehmerAdminForm";
                Label tempLabel = this.Controls.Find(tempNameLabel, true).FirstOrDefault() as Label;
                TextBox tempTextBox = this.Controls.Find(tempNameTextBox, true).FirstOrDefault() as TextBox;
                int nennwertTemp = Convert.ToInt32(tempLabel.Text);
                int anzahlTempBevor = banknoteNennwertCount[nennwertTemp];

                if (!string.IsNullOrEmpty(tempTextBox.Text))
                {
                    anzahl = Convert.ToInt32(tempTextBox.Text);
                }
                int anzahlTempNach = anzahlTempBevor + anzahl;

                banknoteNennwertCount[nennwertTemp] = anzahlTempNach;
                tempTag++;
            }
            BankNoteNennwertDatenSetter();
            MessageBox.Show("Sie haben die Banknoten erfolgreich eingegeben!", "Banknoten Eingebung", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
            
            this.Hide();
        }
        private void buttonAnzahlInfo_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Die Banknoten Anzahl \n \n");
            foreach (var banknote in banknoteNennwertsWährung)
            {
                var währungGewählt = währungDateis.FirstOrDefault(w => w.Id == banknote.Währung_Id);
                sb.Append($"\n{banknote.Nennwert} {währungGewählt.Abkürzung} --- {banknote.Anzahl} x");
            }
            string anzahlInfo = sb.ToString();
            MessageBox.Show($"{anzahlInfo}", "Banknoten Anzahl", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void buttonZurückOperationsGeschichteForm_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.Show();

            this.Hide();
        }
    }
}
