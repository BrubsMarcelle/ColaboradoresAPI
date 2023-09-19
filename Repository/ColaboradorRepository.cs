using ColaboradoresAPI.Data;
using ColaboradoresAPI.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ColaboradoresAPI.Repository
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly ColaboradoresContext _context;

        public ColaboradorRepository(ColaboradoresContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ColaboradoresModel>> BuscarColaboradores()
        {
            return await _context.COLABORADORES.ToListAsync();
        }

        public async Task<ColaboradoresModel> BuscarColaboradorPorId(int id)
        {
            return await _context.COLABORADORES.Where(x => x.id == id).FirstOrDefaultAsync();
        }
        public async Task<ColaboradoresModel> BuscarColaboradorPorNome(string nome)
        {
            return await _context.COLABORADORES.Where(x => x.NOME == nome).FirstOrDefaultAsync();
        }

        public void AdicionarColaborador(ColaboradoresModel colab)
        {
            _context.Add(colab);
        }

        public void AtualizarColaborador(ColaboradoresModel colab)
        {
            _context.Update(colab);
        }

        public void DeletarColaborador(ColaboradoresModel colab)
        {
            _context.Remove(colab);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
