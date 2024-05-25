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
    public partial class UserControlDataTableKunde : UserControl
    {
        public string datumUndZeit
        {
            get { return DatumUndZeitDaten.Text; }
            set { DatumUndZeitDaten.Text = value; }
        }

        public string Abhebung
        {
            get { return AbhebungDaten.Text; }
            set { AbhebungDaten.Text = value; }
        }

        public string Währung
        {
            get { return WährungDaten.Text; }
            set { WährungDaten.Text = value; }
        }


    }

}

