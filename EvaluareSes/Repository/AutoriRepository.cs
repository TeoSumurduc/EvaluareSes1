
using EvaluareSes.Data;
using EvaluareSes.Interface;
using EvaluareSes.Models;

namespace EvaluareSes.Repository
{
    public class AutoriRepository : IAutori
    {
        private readonly DataContext _context;
        public AutoriRepository(DataContext context)
        {
            _context = context;
        }

        public bool AutorExista(int codAutor)
        {
            return _context.Autori.Any(a => a.CodAutor == codAutor);
        }

        public bool CreateAutor(int codCarte, Autori autor)
        {
            var autoriCartiEntity = _context.Carti.Where(a => a.CodCarte == codCarte).FirstOrDefault();

            var autorCarti = new AutoriCarti()
            {
                Carti = autoriCartiEntity,
                Autori = autor,

            };

            _context.Add(autorCarti);
            _context.Add(autor);
            return Save();
        }

        public Autori GetAutor(int codAutor)
        {
            return _context.Autori.Where(p => p.CodAutor == codAutor).FirstOrDefault();
        }

        public ICollection<Autori> GetAutori()
        {
            return _context.Autori.OrderBy(P => P.CodAutor).ToList();
        }

        public string GetAutorNumePrenume(int codAutor)
        {
            var autor = _context.Autori.FirstOrDefault(a => a.CodAutor == codAutor);
            if (autor == null)
            {
                return null;
            }
            var nume = autor.Nume ?? string.Empty;
            var prenume = autor.Prenume ?? string.Empty;
            return nume + " " + prenume;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
