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
    public partial class UserControlDataAdmin : UserControl
    {
        public UserControlDataAdmin()
        {
            InitializeComponent();
        }
        public string DatumUndZeit
        {
            get { return DatumUndZeitAdmin.Text; }
            set { DatumUndZeitAdmin.Text = value; }
        }
        public string KundeName
        {
            get { return KundeNameAdmin.Text; }
            set { KundeNameAdmin.Text = value; }
        }
        public string Iban
        {
            get { return IbanAdmin.Text; }
            set { IbanAdmin.Text = value; }
        }
        public string Abhebung
        {
            get { return AbhebungAdmin.Text; }
            set { AbhebungAdmin.Text = value; }
        }

        public string Währung
        {
            get { return WährungAdmin.Text; }
            set { WährungAdmin.Text = value; }
        }
    }
}
