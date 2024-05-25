namespace Bankautomat
{
    public interface IWährungDatei
    {
        int Id { get; set; }
        string Bezeichnung { get; set; }
        string Abkürzung { get; set; }
        decimal Umrechnungsfaktor { get; set; }
    }
}
