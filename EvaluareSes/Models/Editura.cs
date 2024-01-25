namespace EvaluareSes.Models
{
    public class Editura
    {
        public int CodEditura { get; set; }
        public string Denumire { get; set; }
        public ICollection<Autori> Autori { get; set; }
    }
}
