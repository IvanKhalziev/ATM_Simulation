using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bankautomat
{
    public partial class WillkommenForm : Form
    {
        DatenBankZugriff bankZugriff = new DatenBankZugriff();
        BankKundeDatei account = new BankKundeDatei();
        public WillkommenForm()
        {
            InitializeComponent();
        }
        private void buttonSubmitWillkommenForm_Click(object sender, EventArgs e)
        {
            account = KundeDatenNehmer();
            if (account != null)
            {
                OperationForm operationForm = new OperationForm(account);
                operationForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Entschuldigung, Sie haben eine ungültige IBAN eingegeben. \nBitte versuchen Sie es erneut.", "Ungültige IBAN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
        private void WillkommenForm_Load(object sender, EventArgs e)
        {
            textBoxIBANWillkommenForm.Focus();
            this.AcceptButton = buttonSubmitWillkommenForm;
        }
        private BankKundeDatei KundeDatenNehmer()
        {
            BankKundeDatei accountLokal = new BankKundeDatei();
            string bekommenIban = textBoxIBANWillkommenForm.Text;
            string connectionString = $"Data Source={bankZugriff.serverInstance};Initial Catalog={bankZugriff.dataBaseName};User ID={bankZugriff.userName};Password={bankZugriff.password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM BankKundeVersion2 WHERE kontonummer = @bekommenIban";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@bekommenIban", bekommenIban);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            accountLokal.Id = Convert.ToInt32(reader["id"]);
                            accountLokal.Name = reader["name"].ToString();
                            accountLokal.KontoNummer = reader["kontonummer"].ToString();
                            accountLokal.Pincode = Convert.ToInt32(reader["pincode"]);
                            accountLokal.SaldoEuro = Convert.ToDecimal(reader["saldoeuro"]);
                            return accountLokal;
                        }
                        else
                        {
                            return accountLokal = null;
                        }
                    }
                }
            }
        }
        private void btnExitProgram_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAdminWillkommenFOrm_Click(object sender, EventArgs e)
        {
            AdminForm admin = new AdminForm();
            admin.Show();

            this.Hide();
        }

        private void WillkommenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}