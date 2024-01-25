using EvaluareSes.Models;

namespace EvaluareSes.Interface
{
    public interface IAutori
    {
        ICollection<Autori> GetAutori();
        Autori GetAutor(int codAutor);
        string GetAutorNumePrenume(int codAutor);
        bool AutorExista(int codAutor);
        bool CreateAutor(int codCarte, Autori autor);
        bool Save();
    }
}
