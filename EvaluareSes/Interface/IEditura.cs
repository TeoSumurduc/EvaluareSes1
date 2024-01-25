using EvaluareSes.Models;

namespace EvaluareSes.Interface
{
    public interface IEditura
    {
        ICollection<Editura> GetEdituri();
        Editura GetEditura(int codEditura);
        string GetDenumire(int codEditura);
        bool EdituraExista(int codEditura);
        bool CreateEditura( Editura editura);
        bool Save();
    }
}
