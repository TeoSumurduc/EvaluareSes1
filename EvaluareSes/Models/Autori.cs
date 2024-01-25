using Microsoft.AspNetCore.Components.Forms;

namespace EvaluareSes.Models
{
    public class Autori
    {
        public int CodAutor { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        public ICollection<AutoriCarti> AutoriCarti { get; set; }
        public Editura Editura { get; set; }
    }
}
