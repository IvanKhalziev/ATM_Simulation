namespace Bankautomat
{
    public class BankKundeDatei : IBankKundeDatei
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string KontoNummer { get; set; }
        public int Pincode { get; set; }
        public decimal SaldoEuro { get; set; }
    }
}
