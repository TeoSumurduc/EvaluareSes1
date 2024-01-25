namespace EvaluareSes.Models
{
    public class AutoriCarti
    {
        public int CodCarte { get; set; }
        public int CodAutor { get; set; }
        public Autori Autori { get; set; }
        public Carti Carti { get; set; }

    }
}
