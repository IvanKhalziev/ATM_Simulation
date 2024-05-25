namespace Bankautomat
{
    public interface IBankKundeDatei
    {

        int Id { get; set; }
        string Name { get; set; }
        string KontoNummer { get; set; }
        int Pincode { get; set; }
        decimal SaldoEuro { get; set; }
    }
}
