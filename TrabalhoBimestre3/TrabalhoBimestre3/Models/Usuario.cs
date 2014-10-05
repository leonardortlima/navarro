using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrabalhoBimestre3.Models
{
    public class Usuario
    {
        [Required]
        [MinLength(3)]
        [DisplayName("Nome completo")]
        public String NomeCompleto { get; set; }

        [Required]
        [Range(typeof(DateTime), "1/1/1900", "1/1/2015", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [DisplayName("Data de nascimento")]
        public String DataNascimento { get; set; }

        [Required]
        [MinLength(3)]
        [DisplayName("Nome de usuário")]
        public String NomeUsuario { get; set; }

        [Required]
        [MinLength(6)]
        [DisplayName("Senha do usuário")]
        public String Senha { get; set; }

        [Required]
        [MinLength(6)]
        [DisplayName("Confirmacao da senha")]
        public String ConfirmaSenha { get; set; }
        
    }
}