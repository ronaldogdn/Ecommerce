using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    /*Annotations ASP.NET Core*/
    //nome da tabela
    [Table("Produtos")]
    public class Produto
    {
        public Produto()
        {
            CriadoEm = DateTime.Now;
        }
        //chave primária
        [Key]
        public int ProdutoId { get; set; }

        //display é onde aparece o que é exibido no html
        [Display(Name = "Nome do produto:")]
        //Campo requerido
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Descrição do produto:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        //tamanho mínimo de caracteres
        [MinLength(5,ErrorMessage = "No mínimo 5 caracteres")]
        //tamanho máximo de caracteres
        [MaxLength(100, ErrorMessage = "No máximo 100 caracteres")]
        public string Descricao { get; set; }

        [Display(Name = "Preço do produto:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        //o ? significa que a var pode ser nula
        public double? Preco { get; set; }

        [Display(Name = "Quantidade do produto:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        //limites que os valores podem receber
        [Range(1,1000, ErrorMessage ="Os valore devem estar entre 1 e 1000!")]
        public int? Quantidade { get; set; }
        public DateTime CriadoEm { get; set; }
        public Categoria Categoria { get; set; }
        public string Imagem { get; set; }
    }
}
