namespace EvaluareSes.Models
{
    public class Carti
    {
        public int CodCarte { get; set; }
        public string Denumire { get; set; }

        public ICollection<AutoriCarti> AutoriCarti { get; set; }
    }
}
