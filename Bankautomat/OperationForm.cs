using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace Bankautomat
{
    public partial class OperationForm : Form
    {
        public CultureInfo germanCulture = new CultureInfo("de-DE");
        // CultureInfo usaCulture = new CultureInfo("en-US");
        DatenBankZugriff bankZugriff = new DatenBankZugriff();
        private BankKundeDatei _account;
        private string abkürzungGewählt;
        private decimal saldoGewählt = 0;
        private decimal abhebung = 0;
        List<WährungDatei> währungDateis = new List<WährungDatei>();
        public OperationForm(BankKundeDatei account)
        {
            InitializeComponent();
            this._account = account;
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
        private void OperationForm_Load(object sender, EventArgs e)
        {
            textBoxAbhebungFormOperation.Focus();
            this.AcceptButton = buttonAbhebungOperationForm;
            labelBegrüssungOperationForm.Text = $"Guten Tag, {_account.Name}!";
            saldoGewählt = _account.SaldoEuro;
            abkürzungGewählt = "€";
            string saldoTemp = _account.SaldoEuro.ToString("N2", germanCulture);
            labelKontoAnzeigenOperationForm.Text = $"Auf Ihrem Konto liegt jetzt {saldoTemp} {abkürzungGewählt}";
            WährungDatenNehmer();

            var währung1id = währungDateis.FirstOrDefault();
            StripMenuOperationForm.Text = $"{währung1id.Abkürzung} {währung1id.Bezeichnung}";
            StripMenuOperationForm.Tag = währung1id.Id;
            foreach (var währung in währungDateis.Where(w => w.Id != 1))
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Name = $"ToolStripMenuItem{währung.Bezeichnung}";
                menuItem.Text = $"{währung.Abkürzung} {währung.Bezeichnung}";
                menuItem.Tag = währung.Id;

                menuItem.Click += WährungTauschEvent;
                StripMenuOperationForm.DropDownItems.Add(menuItem);
            }
        }
        private void buttonHomeOperationForm_Click(object sender, EventArgs e)
        {
            WillkommenForm willkommenForm = new WillkommenForm();
            willkommenForm.Show();

            this.Hide();
        }
        private void WährungTauschEvent(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem gedrücktTemp)
            {
                string formText = StripMenuOperationForm.Text;
                int formTag = (int)StripMenuOperationForm.Tag;

                StripMenuOperationForm.Text = gedrücktTemp.Text;
                StripMenuOperationForm.Tag = gedrücktTemp.Tag;
                gedrücktTemp.Text = formText;
                gedrücktTemp.Tag = formTag;

                int idGewählt = (int)StripMenuOperationForm.Tag;

                var währungGewählt = währungDateis.FirstOrDefault(w => w.Id == idGewählt);
                decimal saldoTempDecimal = _account.SaldoEuro * währungGewählt.Umrechnungsfaktor;

                string saldoTemp = saldoTempDecimal.ToString("N2", germanCulture);
                abkürzungGewählt = währungGewählt.Abkürzung;
                saldoGewählt = saldoTempDecimal;
                labelKontoAnzeigenOperationForm.Text = $"Auf Ihrem Konto liegt jetzt: {saldoTemp} {währungGewählt.Abkürzung}";
                labelAchtungOperationForm.Text = $"Achtung! Sie müssen mindestens 10 {währungGewählt.Abkürzung} abheben!";
            }
        }
        private void textBoxAbhebungFormOperation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        private void buttonAbhebungOperationForm_Click(object sender, EventArgs e)
        {
            WährungDatei währung = währungDateis.Where(w => w.Abkürzung == abkürzungGewählt).FirstOrDefault();
            if (textBoxAbhebungFormOperation.Text.Length > 0)
            {
                abhebung = Convert.ToDecimal(textBoxAbhebungFormOperation.Text);
                if (abhebung < 10)
                {
                    MessageBox.Show($"Sie möchten {abhebung.ToString("N2", germanCulture)} {währung.Abkürzung} abheben. \nBitte beachten Sie: Sie müssen mindestens 10 {währung.Abkürzung} abheben", "Kleinster Betrag", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (abhebung > saldoGewählt)
                {
                    MessageBox.Show($"Sie möchten {abhebung.ToString("N2", germanCulture)} {währung.Abkürzung} abheben. \nBitte beachten Sie: Auf Ihrem Konto liegt: {saldoGewählt.ToString("N2", germanCulture)} {währung.Abkürzung}. \nSie haben kein Kredit Limit!", "Kredit Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    OperationEndungForm operationEndungForm = new OperationEndungForm(_account, währung, abhebung);
                    operationEndungForm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Bitte geben Sie einen Betrag ein.");
            }
        }
        private void buttonOperationsGeschichteForm_Click(object sender, EventArgs e)
        {
            OperationsGeschichteForm operations = new OperationsGeschichteForm(_account, währungDateis);
            operations.Show();

            this.Hide();
        }
    }
}
