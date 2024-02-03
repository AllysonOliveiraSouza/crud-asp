using SistemaDeContatos.Data;
using SistemaDeContatos.Models;

namespace SistemaDeContatos.Repositorio
{
	public class ContatoRepositorio : IContatoRepositorio
	{
		private readonly BancoContexto _bancoContexto;

		public ContatoRepositorio(BancoContexto bancoContexto)
		{
			_bancoContexto = bancoContexto;
		}

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContexto.Contatos.Add(contato);
            _bancoContexto.SaveChanges();
            return contato;
        }

        public ContatoModel ListarPorId(int Id)
        {
            return _bancoContexto.Contatos.FirstOrDefault(b => b.Id == Id);

        }

        public ContatoModel Alterar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);
            if (contatoDB == null) throw new Exception("Erro no banco de dados !");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContexto.Update(contatoDB);
            _bancoContexto.SaveChanges();

            return contatoDB;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContexto.Contatos.ToList();
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);
            if (contatoDB == null) throw new Exception("Erro no banco de dados !");

            _bancoContexto.Remove(contatoDB);
            _bancoContexto.SaveChanges();
            return true;
        }
    }
}
