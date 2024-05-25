using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Serialization;

namespace Bankautomat
{
    public partial class PinCodeForm : Form
    {
        public CultureInfo germanCulture = new CultureInfo("de-DE");
        Dictionary<int, int> _banknoteNennwertCount = new Dictionary<int, int>();
        private List<BanknoteNennwert> _banknoteNennwert = new List<BanknoteNennwert>();
        BankKundeDatei _account = new BankKundeDatei();
        WährungDatei _währung = new WährungDatei();
        decimal _abhebung;
        decimal _münzen;
        DatenBankZugriff bankZugriff = new DatenBankZugriff();
        private int versuch = 1;

        public PinCodeForm(Dictionary<int, int> banknoteNennwertCount, List<BanknoteNennwert> banknoteNennwert, BankKundeDatei account, WährungDatei währung, decimal abhebung, decimal münzen)
        {
            InitializeComponent();
            this._banknoteNennwertCount = banknoteNennwertCount;
            this._banknoteNennwert = banknoteNennwert;
            this._account = account;
            this._währung = währung;
            this._abhebung = abhebung;  
            this._münzen = münzen;  
        }
        

        private void Append(char zeichen)
        {
            if (labelPasswortPinCodeForm.Text.Length >= 4) { }
            else { labelPasswortPinCodeForm.Text += zeichen; }
        }
        private string AbschlussInfoSetter()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Sie bekommen {_abhebung.ToString("N2", germanCulture)} {_währung.Abkürzung} \n \nDie Banknoten sind:");
            foreach (var banknote in _banknoteNennwertCount)
            {
                sb.Append($"\n{banknote.Key} {_währung.Abkürzung} -- {banknote.Value} x");
            }
            sb.Append($"\n \nSie bekommen in Münzen: \n{_münzen.ToString("N2", germanCulture)} {_währung.Abkürzung}");
            return sb.ToString();
        }
        private void KundeDatenAktualisierung()
        {
            string connectionString = $"Data Source={bankZugriff.serverInstance};Initial Catalog={bankZugriff.dataBaseName};User ID={bankZugriff.userName};Password={bankZugriff.password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE BankKundeVersion2 \r\nSET saldoeuro = @saldoEuro \r\nWHERE id = @id;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", _account.Id);

                    decimal saldoEuroTemp = _account.SaldoEuro - (_abhebung / _währung.Umrechnungsfaktor);
                    command.Parameters.Add("@saldoEuro", SqlDbType.SmallMoney).Value = decimal.Parse(saldoEuroTemp.ToString("N2", germanCulture));
                    command.ExecuteNonQuery();
                }
            }
        }
        private void BanknotenDatenAktualisierung()
        {
            string connectionString = $"Data Source={bankZugriff.serverInstance};Initial Catalog={bankZugriff.dataBaseName};User ID={bankZugriff.userName};Password={bankZugriff.password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (var banknote in _banknoteNennwert)
                {
                    string query = "UPDATE BanknoteNennwert \r\nSET anzahl = @anzahl \r\nWHERE id = @id;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", banknote.Id);
                        if (_banknoteNennwertCount.ContainsKey(banknote.Nennwert))
                        {
                            int anzahlTempCount = _banknoteNennwertCount[banknote.Nennwert];
                            if (anzahlTempCount != 0)
                            {
                                int anzahlTemp = banknote.Anzahl - anzahlTempCount;
                                command.Parameters.Add("@anzahl", SqlDbType.Int).Value = anzahlTemp;
                            }
                            else { command.Parameters.Add("@anzahl", SqlDbType.Int).Value = banknote.Anzahl; }

                        }
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        private void OperationsGeschichteDatenErstellung()
        {
            string connectionString = $"Data Source={bankZugriff.serverInstance};Initial Catalog={bankZugriff.dataBaseName};User ID={bankZugriff.userName};Password={bankZugriff.password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO OperationsGeschichte (abhebung, BankKundeVersion2ID, WaehrungDatenID) \r\nVALUES (@abhebung, @bankKundeID,  @waehrungDatenID);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@abhebung", _abhebung);
                    command.Parameters.AddWithValue("@bankKundeID", _account.Id);
                    command.Parameters.AddWithValue("@waehrungDatenID", _währung.Id);
                    command.ExecuteNonQuery();
                }

            }
        }
        private void buttonEntwerfenPinCodeForm_Click(object sender, EventArgs e)
        {
            string temp = labelPasswortPinCodeForm.Text;
            if (string.IsNullOrEmpty(temp)) { }
            else { labelPasswortPinCodeForm.Text = temp.Substring(0, temp.Length - 1); }
        }
        private void buttonWeiterPinCodeForm_Click(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32(labelPasswortPinCodeForm.Text);
            if (versuch <= 3)
            {
                if (labelPasswortPinCodeForm.Text.Length != 4)
                {
                    MessageBox.Show("Geben Sie einen gültigen PIN-Code ein", "Ungültiger PIN-Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (temp != _account.Pincode)
                {
                    MessageBox.Show($"Ungültiger PIN-Code. \nVersuchen Sie es erneut. Sie haben noch {3 - versuch} Versuche", "Ungültiger PIN-Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    versuch++;
                    if(versuch > 3)
                    {
                        MessageBox.Show("Sie haben keine Versuche mehr \nIhre Sitzung wird beendet.", "Ungültiger PIN-Code", MessageBoxButtons.OK, MessageBoxIcon.Stop); Environment.Exit(0);
                    }
                }
                else
                {
                    KundeDatenAktualisierung();
                    BanknotenDatenAktualisierung();
                    OperationsGeschichteDatenErstellung();
                    string abschlussInfo = AbschlussInfoSetter();
                    MessageBox.Show(abschlussInfo, "Banknoten Auswahl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Vielen Dank für die Nutzung unserer Bank!", "Abschluß", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }
            }
            else {MessageBox.Show("Sie haben keine Versuche mehr \nIhre Sitzung wird beendet.", "Ungültiger PIN-Code", MessageBoxButtons.OK, MessageBoxIcon.Stop); Environment.Exit(0);};
             
        }
        private void CodeFormClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Append(Convert.ToChar(button.Tag));
        }
        private void btnExitProgram_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}