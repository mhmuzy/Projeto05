using System;
using Projeto05.Controllers;
using Projeto05.Repositories;

namespace Projeto05
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Informe (1) LINQ ou (2) LAMBDA.....: ");
                var opcao = int.Parse(Console.ReadLine());

                ProdutoController produtoController = null; //sem espaço de memória (vazio)

                switch (opcao)
                {
                    case 1:
                        //POLIMORFISMO
                        produtoController = new ProdutoController(new ProdutoRepositoryLINQ());
                        break;

                    case 2:
                        //POLIMORFISMO
                        produtoController = new ProdutoController(new ProdutoRepositoryLAMBDA());
                        break;

                    default:
                        //TODO
                        break;
                }

                produtoController.CadastrarProduto(); //executando o cadastro

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            Console.ReadKey(); //pausar a execução
        }
    }
}
