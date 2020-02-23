using Dapper.Contrib.Extensions;
using System;

namespace CadastroCliente.Models
{
    [Table("dbclientes.cliente")]
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public char Sexo { get; set; }

        public string Cep { get; set; }

        public string Endereco { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Estado { get; set; }

        public string Cidade { get; set; }
    }
}
