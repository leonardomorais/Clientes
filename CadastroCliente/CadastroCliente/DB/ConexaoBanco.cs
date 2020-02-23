using MySql.Data.MySqlClient;
using System;

namespace CadastroCliente.DB
{
    public class ConexaoBanco
    {
        private static string conexao = "server=127.0.0.1;uid=root;pwd='';database=dbclientes";

        private static MySqlConnection conexaoMySQL;

        public static MySqlConnection ObterConexao()
        {
            try
            {
                if (conexaoMySQL == null)
                {
                    conexaoMySQL = new MySqlConnection(conexao);
                    conexaoMySQL.Open();
                }
                return conexaoMySQL;
            }
            catch (MySqlException e)
            {
                throw new Exception("Falha ao conectar ao banco de dados MySQL - " + e.Message);
            }

        }
    }
}
