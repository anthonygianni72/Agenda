using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgendaDesafioAPI.Models
{
    public class Agenda
    {
        public Agenda() { }
        public Agenda(int Id,string Nome,string Email,string Telefone) { 
            this.Id=Id;
            this.Nome=Nome;
            this.Email=Email;
            this.Telefone=Telefone;
        }
        public int Id { get; set; }

        [DisplayName("Primeiro Nome")]
        [StringLength(50, ErrorMessage = "O campo Nome permite no máximo 50 caracteres!")]
        public string Nome { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Informe o Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inválido.")]
        public string Email { get; set; }
        public string Telefone { get; set; }

    }
}
