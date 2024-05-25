using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bankautomat
{
    public partial class OperationsGeschichteAdmin : Form
    {
        public CultureInfo germanCulture = new CultureInfo("de-DE");
        DatenBankZugriff bankZugriff = new DatenBankZugriff();
        List<OperationsGeschichteDaten> alleOperations = new List<OperationsGeschichteDaten>();
        List<WährungDatei> alleWährungs = new List<WährungDatei>();
        List<BankKundeDatei> alleAccounts = new List<BankKundeDatei>();
        private class OGAdmin
        {
            public int Id { get; set; }
            public string Datum_Zeit { get; set; }
            public string KundeName { get; set; }
            public string IBAN { get; set; }
            public string Abhebung { get; set; }
            public string Waehrung { get; set; }
        }
        List<OGAdmin> alleOGAdmin = new List<OGAdmin>();
        public OperationsGeschichteAdmin()
        {
            InitializeComponent();
        }
        private void KundeDatenNehmer()
        {
            string connectionString = $"Data Source={bankZugriff.serverInstance};Initial Catalog={bankZugriff.dataBaseName};User ID={bankZugriff.userName};Password={bankZugriff.password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM BankKundeVersion2";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            BankKundeDatei account = new BankKundeDatei();
                            account.Id = Convert.ToInt32(reader["id"]);
                            account.Name = reader["name"].ToString();
                            account.KontoNummer = reader["kontonummer"].ToString();
                            account.Pincode = Convert.ToInt32(reader["pincode"]);
                            account.SaldoEuro = Convert.ToDecimal(reader["saldoeuro"]);
                            alleAccounts.Add(account);
                        }
                    }
                }
            }
        }
        private void OperationsGeschichteDatenNehmer()
        {
            string connectionString = $"Data Source={bankZugriff.serverInstance};Initial Catalog={bankZugriff.dataBaseName};User ID={bankZugriff.userName};Password={bankZugriff.password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM OperationsGeschichte";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OperationsGeschichteDaten operation = new OperationsGeschichteDaten();
                            operation.Id = Convert.ToInt32(reader["id"]);
                            operation.Datum_Zeit = reader["datum_zeit"].ToString().Trim();
                            operation.Abhebung = Convert.ToDecimal(reader["abhebung"]);
                            operation.BankKundeID = Convert.ToInt32(reader["BankKundeVersion2ID"]);
                            operation.WaehrungID = Convert.ToInt32(reader["WaehrungDatenID"]);
                            alleOperations.Add(operation);
                        }
                    }
                }
            }
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
                            alleWährungs.Add(währung);
                        }
                    }
                }
            }
        }
        private void OperationsGeschichteAdmin_Load(object sender, EventArgs e)
        {
            KundeDatenNehmer();
            OperationsGeschichteDatenNehmer();
            WährungDatenNehmer();

            if (alleOperations != null)
            {
                for (int i = 0; i < alleOperations.Count; i++)
                {
                    OGAdmin table = new OGAdmin();
                    var operation = alleOperations.Reverse<OperationsGeschichteDaten>().ElementAt(i);
                    var account = alleAccounts.Where(a => a.Id == operation.BankKundeID).FirstOrDefault();
                    var währungGewählt = alleWährungs.Where(w => w.Id == operation.WaehrungID).FirstOrDefault();
                    table.Id = operation.Id;
                    table.Datum_Zeit = operation.Datum_Zeit;
                    table.KundeName = account.Name;
                    table.IBAN = account.KontoNummer;
                    table.Waehrung = währungGewählt.Abkürzung.ToString();
                    table.Abhebung = operation.Abhebung.ToString("N2", germanCulture);
                    alleOGAdmin.Add(table);
                }

                for (int i = 0; i < alleOGAdmin.Count; i++)
                {
                    UserControlDataAdmin UCDT = new UserControlDataAdmin();
                    UCDT.DatumUndZeit = alleOGAdmin[i].Datum_Zeit;
                    UCDT.KundeName = alleOGAdmin[i].KundeName;
                    UCDT.Iban = alleOGAdmin[i].IBAN;
                    UCDT.Währung = alleOGAdmin[i].Waehrung;
                    UCDT.Abhebung = alleOGAdmin[i].Abhebung;
                    
                    tableLayoutPanelDataTable.Controls.Add(UCDT, 0, i);
                }
            }
        }
        private void buttonZurückOperationsGeschichteForm_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.Show();

            this.Hide();
        }

    }
}
