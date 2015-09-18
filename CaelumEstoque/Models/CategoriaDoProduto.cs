 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaelumEstoque.Models
{
    public class CategoriaDoProduto
    {
        [Required]
        public int Id { get; set; }

        public String Nome { get; set; }

        public String Descricao { get; set; }
    }
}