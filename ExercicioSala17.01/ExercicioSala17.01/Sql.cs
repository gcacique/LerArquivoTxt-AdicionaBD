using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ExercicioSala17._01
{
    public class Sql
    {
        private readonly SqlConnection _conexao;
        public Sql()
        {
            string lertexto = System.IO.File.ReadAllText(@"C:\Users\glcac\Documents\Curso RUMO\servidorSql.txt");
            //this._conexao = new SqlConnection ()
        }

        public void inserirDados(dadosClientes cliente)
        {
            try
            {
                _conexao.Open();

                string sql = @"INSERT INTO Cliente
                             (Cpf,Nome,Idade,Genero,Nacionalidade)
                             VALUES
                             (@Cpf,@Nome,@Idade,@Genero,@Nacionalidade);";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("Cpf", cliente.cpf);
                    cmd.Parameters.AddWithValue("Nome", cliente.nome); 
                    cmd.Parameters.AddWithValue("Idade", cliente.idade);
                    cmd.Parameters.AddWithValue("Genero", cliente.sexo);
                    cmd.Parameters.AddWithValue("Nacionalidade", cliente.nacionalidade);
                    cmd.ExecuteNonQuery();
                }
              
            }
            finally
            {
                _conexao.Close();
            }
        }
    }
}
