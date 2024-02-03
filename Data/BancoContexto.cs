using Microsoft.EntityFrameworkCore;
using SistemaDeContatos.Models;

namespace SistemaDeContatos.Data
{
	public class BancoContexto : DbContext
	{
		public BancoContexto(DbContextOptions<BancoContexto> opcoes) :base(opcoes) { 
		}

		public DbSet<ContatoModel> Contatos { get; set; }
	}
}
