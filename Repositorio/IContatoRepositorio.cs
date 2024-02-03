using SistemaDeContatos.Models;

namespace SistemaDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();
        public ContatoModel Adicionar(ContatoModel contato);

        ContatoModel ListarPorId(int Id);

        ContatoModel Alterar(ContatoModel contato);

        bool Apagar(int id);
    }
}
