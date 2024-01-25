
using EvaluareSes.Data;
using EvaluareSes.Interface;
using EvaluareSes.Models;

namespace EvaluareSes.Repository
{
    public class EdituraRepository : IEditura
    {
        private readonly DataContext _context;
        public EdituraRepository(DataContext context)
        {
            _context = context;
        }

        public bool EdituraExista(int codEditura)
        {
            return _context.Editura.Any(a => a.CodEditura == codEditura);
        }

        public bool CreateEditura(Editura editura)
        {

            _context.Add(editura);
            return Save();
        }

        public Editura GetEditura(int codEditura)
        {
            return _context.Editura.Where(p => p.CodEditura == codEditura).FirstOrDefault();
        }

        public ICollection<Editura> GetEdituri()
        {
            return _context.Editura.OrderBy(P => P.CodEditura).ToList();
        }

        public string GetDenumire(int codEditura)
        {
            var editura = _context.Editura.FirstOrDefault(a => a.CodEditura == codEditura);
            if (editura == null)
            {
                return null;
            }
            string nume = editura.Denumire ; 
            return nume;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        
    }
}
