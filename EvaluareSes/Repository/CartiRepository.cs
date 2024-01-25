
using EvaluareSes.Data;
using EvaluareSes.Interface;
using EvaluareSes.Models;

namespace EvaluareSes.Repository
{
    public class CartiRepository : ICarti
    {
        private readonly DataContext _context;
        public CartiRepository(DataContext context)
        {
            _context = context;
        }

        public bool CarteExista(int codCarte)
        {
            return _context.Carti.Any(a => a.CodCarte == codCarte);
        }

        public bool CreateCarte(int codAutor, Carti carte)
        {
            var cartiAutoriEntity = _context.Autori.Where(a => a.CodAutor == codAutor).FirstOrDefault();

            var cartiAutori = new AutoriCarti()
            {
                Autori = cartiAutoriEntity,
                Carti = carte,

            };

            _context.Add(cartiAutori);
            _context.Add(carte);
            return Save();
        }

        public Carti GetCarte(int codCarte)
        {
            return _context.Carti.Where(p => p.CodCarte == codCarte).FirstOrDefault();
        }

        public ICollection<Carti> GetCarti()
        {
            return _context.Carti.OrderBy(P => P.CodCarte).ToList();
        }

        public string GetDenumire(int codCarte)
        {
            var carte = _context.Carti.FirstOrDefault(a => a.CodCarte == codCarte);
            if (carte == null)
            {
                return null;
            }
            var nume = carte.Denumire ?? string.Empty;
            return nume;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
