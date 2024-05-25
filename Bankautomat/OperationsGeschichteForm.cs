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
    public partial class OperationsGeschichteForm : Form
    {
        public CultureInfo germanCulture = new CultureInfo("de-DE");
        DatenBankZugriff bankZugriff = new DatenBankZugriff();
        BankKundeDatei _account = new BankKundeDatei();
        List<WährungDatei> _währung = new List<WährungDatei>();
        List<OperationsGeschichteDaten> operationsGeschichteDetails = new List<OperationsGeschichteDaten>();
        private class OperationsGeschichteTable
        {
            public int Id { get; set; }
            public string Datum_Zeit { get; set; }
            public string Abhebung { get; set; }
            public string Waehrung { get; set; }
            public string BankKundeName { get; set; }
        }
        List<OperationsGeschichteTable> operationsGeschichteAlleTables = new List<OperationsGeschichteTable>();
        public OperationsGeschichteForm(BankKundeDatei account, List<WährungDatei> währung)
        {
            this._account = account;
            this._währung = währung;
            InitializeComponent();
        }
        public void OperationsGeschichteDatenNehmer()
        {
            string connectionString = $"Data Source={bankZugriff.serverInstance};Initial Catalog={bankZugriff.dataBaseName};User ID={bankZugriff.userName};Password={bankZugriff.password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM OperationsGeschichte WHERE BankKundeVersion2ID = @bankKundeID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@bankKundeID", _account.Id);
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
                            operationsGeschichteDetails.Add(operation);
                        }
                    }
                }
            }
        }
        private void OperationsGeschichte_Load(object sender, EventArgs e)
        {
            //OperationsGeschichteDatenNehmer();
            //for (int i = 1; i <= operationsGeschichteDateis.Count; i++)
            //{
            //    OperationsGeschichteTable table = new OperationsGeschichteTable();
            //    var operation = operationsGeschichteDateis.Where(o => o.Id == i).FirstOrDefault();
            //    var währungGewählt = _währung.Where(w => w.Id == operation.WaehrungID).FirstOrDefault();
            //    table.Id = operation.Id;
            //    table.Datum_Zeit = operation.Datum_Zeit;
            //    table.Abhebung = operation.Abhebung.ToString("N2", germanCulture);
            //    table.Waehrung = währungGewählt.Abkürzung.ToString();
            //    table.BankKundeName = _account.Name;
            //    operationsGeschichteTable.Add(table);
            //}
            
            //for(int i = 0; i < operationsGeschichteTable.Count;  i++)
            //{
            //    UserControlDataTable UCDT = new UserControlDataTable();
            //    UCDT.datumUndZeit = operationsGeschichteTable[i].Datum_Zeit;
            //    UCDT.Abhebung = operationsGeschichteTable[i].Abhebung;
            //    UCDT.Währung = operationsGeschichteTable[i].Waehrung;
            //    tableLayoutPanelDaten.Controls.Add(UCDT, 0, i);

            //}
        }

        private void buttonZurückOperationsGeschichteForm_Click(object sender, EventArgs e)
        {
            OperationForm operationForm = new OperationForm(_account);
            operationForm.Show();
            this.Hide();
        }

        private void OperationsGeschichteForm_Shown(object sender, EventArgs e)
        {
            OperationsGeschichteDatenNehmer();
            if (operationsGeschichteDetails != null)
            {
                for (int i = 0; i < operationsGeschichteDetails.Count; i++)
                {
                    OperationsGeschichteTable table = new OperationsGeschichteTable();
                    var operation = operationsGeschichteDetails.Reverse<OperationsGeschichteDaten>().ElementAt(i);
                    var währungGewählt = _währung.Where(w => w.Id == operation.WaehrungID).FirstOrDefault();
                    table.Id = operation.Id;
                    table.Waehrung = währungGewählt.Abkürzung.ToString();
                    table.Abhebung = operation.Abhebung.ToString("N2", germanCulture);
                    table.Datum_Zeit = operation.Datum_Zeit;
                    table.BankKundeName = _account.Name;
                    operationsGeschichteAlleTables.Add(table);
                }

                for (int i = 0; i < operationsGeschichteAlleTables.Count; i++)
                {
                    UserControlDataTableKunde UCDT = new UserControlDataTableKunde();
                    UCDT.Währung = operationsGeschichteAlleTables[i].Waehrung;
                    UCDT.Abhebung = operationsGeschichteAlleTables[i].Abhebung;
                    UCDT.datumUndZeit = operationsGeschichteAlleTables[i].Datum_Zeit;
                    tableLayoutPanelDaten.Controls.Add(UCDT, 0, i);

                }
            }
                
        }
    }
}
