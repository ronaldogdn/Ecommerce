using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Enderecos")]
    public class Endereco
    {
        public Endereco()
        {
            CriadoEm = DateTime.Now;
        }
        [Key]
        public int EnderecoId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Rua:")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "CEP:")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Bairro:")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Cidade:")]
        public string Localidade { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Estado:")]
        public string UF { get; set; }

        public DateTime CriadoEm { get; set; }
    }
}
