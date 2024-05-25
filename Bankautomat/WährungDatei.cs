namespace Bankautomat
{
    public class WährungDatei : IWährungDatei
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public string Abkürzung { get; set; }
        public decimal Umrechnungsfaktor { get; set; }
    }
}
