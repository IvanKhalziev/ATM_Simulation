using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bankautomat
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void buttonBanknotenEingebungAdminForm_Click(object sender, EventArgs e)
        {
            BanknotenEingebungAdminForm banknotenEingebungAdmin = new BanknotenEingebungAdminForm();
            banknotenEingebungAdmin.Show();

            this.Hide();    
        }

        private void buttonZurückOperationsGeschichteForm_Click(object sender, EventArgs e)
        {
            WillkommenForm willkommenForm = new WillkommenForm();   
            willkommenForm.Show();      

            this.Hide();    
        }

        private void buttonOperationsGeschichteAdminForm_Click(object sender, EventArgs e)
        {
            OperationsGeschichteAdmin operationsGeschichteAdmin = new OperationsGeschichteAdmin();
            operationsGeschichteAdmin.Show();

            this.Hide();
        }
    }
}
