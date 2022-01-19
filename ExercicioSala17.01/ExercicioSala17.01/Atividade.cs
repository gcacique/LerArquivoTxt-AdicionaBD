using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExercicioSala17._01
{
    public class Atividade
    {
        
        public void importarDados()
                        
        {
            var sql = new Sql();
            


            List<dadosClientes> dadosCadastrais = new List<dadosClientes>();
            string cpf, nome, sexo, idade, nacionalidade;         

            string[] linha = System.IO.File.ReadAllLines(@"C:\Users\glcac\Documents\Curso RUMO\Clientes.txt");

            for(int i = 0; i < linha.Length; i++)
            {
                cpf = linha[i].Substring(0, 11);
                nome = linha[i].Substring(11, 80);
                sexo = linha[i].Substring(91, 1);
                idade = linha[i].Substring(92, 3);
                nacionalidade = linha[i].Substring(95, 20);

                var cliente = new dadosClientes();
                cliente.cpf = cpf;
                cliente.nome = nome;
                cliente.sexo = sexo;
                cliente.idade = idade;
                cliente.nacionalidade = nacionalidade;

                dadosCadastrais.Add(cliente);


            }
            foreach(var dados in dadosCadastrais)
            {
                sql.inserirDados(dados);
            }

            

        }
    }
}
