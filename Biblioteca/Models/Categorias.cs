using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
	public class Categorias
	{
		[Key]
		public int Id { get; set; }
		[Required]
        [DisplayName("Nome")]
        public string? Nome { get; set; }
        [DisplayName("Descrição")]
        public string? Descricao { get; set; }
        [DisplayName("Data de Criação")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;
	}
}