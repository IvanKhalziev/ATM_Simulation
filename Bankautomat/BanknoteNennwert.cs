namespace Bankautomat
{
    public class BanknoteNennwert
    {
        int _id;
        int _nennwert;
        int _anzahl;
        int _währung_Id;

        public int Währung_Id { get => _währung_Id; set =>_währung_Id = value; }
        public int Id { get => _id; set => _id = value; }    
        public int Nennwert { get => _nennwert; set => _nennwert = value; }
        public int Anzahl { get => _anzahl; set => _anzahl = value; }
    }
}
