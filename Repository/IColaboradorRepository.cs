using ColaboradoresAPI.Model;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColaboradoresAPI.Repository
{
    public interface IColaboradorRepository
    {
        Task<IEnumerable<ColaboradoresModel>> BuscarColaboradores();
        Task<ColaboradoresModel> BuscarColaboradorPorId(int id);
        Task<ColaboradoresModel> BuscarColaboradorPorNome(string nome);
        void AdicionarColaborador(ColaboradoresModel colab);
        void AtualizarColaborador(ColaboradoresModel colab);
        void DeletarColaborador(ColaboradoresModel colab);
        Task<bool> SaveChangesAsync();
    }
}
