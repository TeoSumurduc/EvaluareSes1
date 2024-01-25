using EvaluareSes.Models;

namespace EvaluareSes.Interface
{
    public interface ICarti 
    {
        ICollection<Carti> GetCarti();
        Carti GetCarte(int codCarte);
        string GetDenumire(int codCarte);
        bool CarteExista(int codCarte);
        bool CreateCarte(int codAutor, Carti carte);
        bool Save();
    }
}
