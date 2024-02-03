using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeContatos.Models
{
	[Table("Tb_Contato")]
	public class ContatoModel
	{
		[Column("Id")]
		public int Id { get; set; }

		[Column("Nome")]
		[Required(ErrorMessage = "Favor inserir o nome !")]
		public string Nome { get; set; }

		[Column("Email")]
        [Required(ErrorMessage = "Favor inserir o e-mail !")]
        public string Email { get; set; }

		[Column("Celular")]
        [Required(ErrorMessage = "Favor inserir o celular !")]
        public string Celular { get; set; }
	}
}
