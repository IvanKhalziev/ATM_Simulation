using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace Bankautomat
{
    public partial class OperationEndungForm : Form
    {
        public CultureInfo germanCulture = new CultureInfo("de-DE");
        private DatenBankZugriff bankZugriff = new DatenBankZugriff();
        private BankKundeDatei _account = new BankKundeDatei();
        private WährungDatei _währung = new WährungDatei();
        private decimal _abhebung;
        private decimal _abhebungOperationForm;
        private List<BanknoteNennwert> banknoteNennwerts = new List<BanknoteNennwert>();
        private Dictionary<int, int> banknoteNennwertCount = new Dictionary<int, int>();
        private List<BanknoteNennwert> banknotenennwertsGewählt = new List<BanknoteNennwert>();
        private List<BanknoteNennwert> banknotenennwertsGewähltOperationEndungForm = new List<BanknoteNennwert>();

        public OperationEndungForm(BankKundeDatei _account, WährungDatei währung, decimal abhebung)
        {
            InitializeComponent();
            this._account = _account;
            this._währung = währung;
            this._abhebung = abhebung;
            this._abhebungOperationForm = abhebung;

            // Verbindung durch buttons und labels (Banknoten Auswahl)
            button101OperationEndungForm.Tag = label101NennwertOperationEndungForm;
            button102OperationEndungForm.Tag = label102NennwertOperationEndungForm;
            button103OperationEndungForm.Tag = label103NennwertOperationEndungForm;
            button104OperationEndungForm.Tag = label104NennwertOperationEndungForm;
            button105OperationEndungForm.Tag = label105NennwertOperationEndungForm;
            button106OperationEndungForm.Tag = label106NennwertOperationEndungForm;
            // Verbindung durch labels und buttons (Banknoten Auswahl)
            label101NennwertOperationEndungForm.Tag = button101OperationEndungForm;
            label102NennwertOperationEndungForm.Tag = button102OperationEndungForm;
            label103NennwertOperationEndungForm.Tag = button103OperationEndungForm;
            label104NennwertOperationEndungForm.Tag = button104OperationEndungForm;
            label105NennwertOperationEndungForm.Tag = button105OperationEndungForm;
            label106NennwertOperationEndungForm.Tag = button106OperationEndungForm;
        }
        private void BankNoteNennwertDatenNehmer()
        {
            string connectionString = $"Data Source={bankZugriff.serverInstance};Initial Catalog={bankZugriff.dataBaseName};User ID={bankZugriff.userName};Password={bankZugriff.password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM BanknoteNennwert WHERE IDWaehrungDaten = @bekommenID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@bekommenID", _währung.Id);
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
        private bool SummeÜberprüfen(List<BanknoteNennwert> banknoteNennwerts, decimal abhebung)
        {
            int summeTemp = 0;
            foreach (var banknote in banknoteNennwerts)
            {
                summeTemp += banknote.Nennwert * banknote.Anzahl;
            }
            if (abhebung - 10 <= summeTemp)
            {
                return true;
            }
            else return false;

        }
        private bool BankNoteNennwertÜberprüfen(int amount, Button clickedButton)
        {
            Button btn = clickedButton;
            int anzahlTemp = banknotenennwertsGewähltOperationEndungForm
                     .Where(b => b.Nennwert == Convert.ToInt32(btn.Text))
                     .Select(b => b.Anzahl).FirstOrDefault();

            if (anzahlTemp >= 1)
            {
                banknoteNennwertCount[amount] += 1;
                var bankNoteToReduce = banknotenennwertsGewähltOperationEndungForm.FirstOrDefault(b => b.Nennwert == Convert.ToInt32(btn.Text));
                bankNoteToReduce.Anzahl -= 1;
                return true;
            }
            else
            {
                clickedButton.BackColor = Color.DimGray;
                clickedButton.ForeColor = Color.DarkSlateGray;
                SetCrossedOutText(clickedButton, amount.ToString());
                MessageBox.Show("Haben keine Banknoten mehr");
                return false;
            }
        }
        private void ButtonZeichner(decimal abhebung)
        {
            int tempTag = 101;
            for (int i = 0; i < 6; i++)
            {
                string tempName = $"button{tempTag}OperationEndungForm";
                Button button = this.Controls.Find(tempName, true).FirstOrDefault() as Button;
                int buttonTextInt = Convert.ToInt32(button.Text);
                if (buttonTextInt > abhebung)
                {
                    button.BackColor = Color.DimGray;
                    button.ForeColor = Color.DarkSlateGray;
                }
                else
                {
                    button.BackColor = Color.Gold;
                    button.ForeColor = Color.RoyalBlue;
                }
                tempTag++;
            }
        }
        private void ButtonZeichnerUndNennwertSetter(List<BanknoteNennwert> banknoteNennwerts)
        {
            int tempTag = 101;
            for (int i = 0; i < 6; i++)
            {
                string tempName = $"button{tempTag}OperationEndungForm";
                Button button = this.Controls.Find(tempName, true).FirstOrDefault() as Button;
                button.Text = $"{banknoteNennwerts[i].Nennwert}";
                banknoteNennwertCount.Add(banknoteNennwerts[i].Nennwert, 0);
                if (banknoteNennwerts[i].Nennwert > _abhebung || banknoteNennwerts[i].Anzahl <= 0)
                {
                    button.BackColor = Color.DimGray;
                    button.ForeColor = Color.DarkSlateGray;
                }
                tempTag++;
            }
        }
        private void OperationEndung(decimal abhebung, decimal abhebungOperationForm)
        {
            int anzahlTemp = banknotenennwertsGewähltOperationEndungForm.FirstOrDefault(b => b.Anzahl > 0)?.Nennwert ?? 0;

            if (abhebung < anzahlTemp)
            {
                PinCodeForm pinCodeForm = new PinCodeForm(banknoteNennwertCount, banknotenennwertsGewählt, _account, _währung, abhebungOperationForm, abhebung);
                pinCodeForm.Show();
                this.Hide();
            }
        }
        private void BanknoteButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int amount = int.Parse(clickedButton.Text);
            if (_abhebung >= amount)
            {
                bool result = BankNoteNennwertÜberprüfen(amount, clickedButton);
                if (result)
                {
                    _abhebung -= amount;
                    ButtonZeichner(_abhebung);
                    OperationEndung(_abhebung, _abhebungOperationForm);
                    string abhebungTemp = _abhebung.ToString("N2", germanCulture);
                    labelAbhebungEndungOperationForm.Text = $"Sie möchten noch {abhebungTemp} {_währung.Abkürzung} abheben! Wählen Sie die Banknoten";
                    if (clickedButton.Tag is System.Windows.Forms.Label associatedLabel)
                    {
                        associatedLabel.Text = $"x {banknoteNennwertCount[amount]}";
                    }
                }
            }
        }
        private void SetCrossedOutText(Button button, string text)
        {
            button.Text = text;
            button.Font = new Font(button.Font, FontStyle.Strikeout);
        }
        private List<BanknoteNennwert> DeepCopyList(List<BanknoteNennwert> originalList)
        {
            List<BanknoteNennwert> copyList = new List<BanknoteNennwert>();
            foreach (var item in originalList)
            {
                BanknoteNennwert copiedItem = new BanknoteNennwert
                {
                    Id = item.Id,
                    Anzahl = item.Anzahl,
                    Nennwert = item.Nennwert,
                    Währung_Id = item.Währung_Id
                };
                copyList.Add(copiedItem);
            }
            return copyList;
        }
        private void buttonHomeOperationEndungForm_Click(object sender, EventArgs e)
        {
            WillkommenForm willkommenForm = new WillkommenForm();
            willkommenForm.Show();
            this.Hide();
        }
        private void OperationEndungForm_Load(object sender, EventArgs e)
        {
            string abhebungTemp = _abhebung.ToString("N2", germanCulture);
            labelAbhebungEndungOperationForm.Text = $"Sie möchten {abhebungTemp} {_währung.Abkürzung} abheben! Wählen Sie die Banknoten";
            BankNoteNennwertDatenNehmer();
            banknotenennwertsGewählt = new List<BanknoteNennwert>(banknoteNennwerts)
                                                .Where(b => b.Währung_Id == _währung.Id).ToList();

            banknotenennwertsGewähltOperationEndungForm = DeepCopyList(banknoteNennwerts).Where(b => b.Währung_Id == _währung.Id).ToList();
            ButtonZeichnerUndNennwertSetter(banknotenennwertsGewählt);
            bool geldReicht = SummeÜberprüfen(banknotenennwertsGewählt, _abhebung);
            if (!geldReicht)
            {
                MessageBox.Show("Entschuldigung, reduzieren Sie die Abheung. \nUnser Bankautomat hat nicht genug Banknoten", "Banknotenmangel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                OperationForm operationForm = new OperationForm(_account);
                operationForm.Show();
            }
        }
        private void BanknoteZurückGeben(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            if (clickedLabel.Text != null && clickedLabel.Tag is Button)
            {
                Button tempButton = clickedLabel.Tag as Button;
                int tempNennwert = Convert.ToInt32(tempButton.Text);
                if (banknoteNennwertCount[tempNennwert] != 0)
                {
                    banknoteNennwertCount[tempNennwert]--;
                    if (banknoteNennwertCount[tempNennwert] != 0) 
                    {
                        clickedLabel.Text = $"x {banknoteNennwertCount[tempNennwert]}";
                    }
                    else { clickedLabel.Text = null; }
                }
                _abhebung += tempNennwert;
                ButtonZeichner(_abhebung);
                string abhebungTemp = _abhebung.ToString("N2", germanCulture);
                labelAbhebungEndungOperationForm.Text = $"Sie möchten noch {abhebungTemp} {_währung.Abkürzung} abheben! Wählen Sie die Banknoten";
            }
        }
    }
}
