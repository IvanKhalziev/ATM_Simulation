using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankautomat
{
    public class OperationsGeschichteDaten
    {
        public int Id { get; set; }
        public string Datum_Zeit { get; set; }
        public decimal Abhebung { get; set; }
        public int WaehrungID { get; set; }
        public int BankKundeID { get; set; }
    }
}
