using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Usuarios")]
    public class Usuario
    {
        public Usuario()
        {
            CriadoEm = DateTime.Now;
            Endereco = new Endereco();
        }

        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Senha:")]
        public string Senha { get; set; }

        //não é gravado no BD
        [NotMapped]
        [Compare("Senha",ErrorMessage ="Os campos não coincidem!")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Repita a senha:")]
        public string ConfirmacaoSenha { get; set; }

        
        [Required(ErrorMessage = "Campo obrigatório!")]
        public Endereco Endereco { get; set; }

        public DateTime CriadoEm { get; set; }
    }
}
