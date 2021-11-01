using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iBarber_WebApp.Models
{
    public class Barbearia
    {
        [Required]

        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Digite o CNPJ da sua barbearia para prosseguir.")]

        public string Nome { get; set; }

        public bool VerificarCPNJBarbearia()
        {
            if (CNPJ == "12345678910123")
                return true;
            else
                return false;
        }

        [Required(ErrorMessage = "Digite o CNPJ da sua barbearia para prosseguir.")]

        public string Local { get; set; }
    }
}
