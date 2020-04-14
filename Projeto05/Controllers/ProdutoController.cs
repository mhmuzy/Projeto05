using System;
using System.Collections.Generic;
using System.Text;
using Projeto05.Abstracts;
using Projeto05.Entities;
using Projeto05.Entities.Enums;

namespace Projeto05.Controllers
{
    public class ProdutoController
    {
        //atributo
        private ProdutoRepositoryAbstract produtoRepository;

        //construtor para incializar o atributo
        public ProdutoController(ProdutoRepositoryAbstract produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        //método para cadastrar um produto..

        public void CadastrarProduto()
        {
            Console.WriteLine("\n - CADASTRO DE PRODUTOS - \n");

            var produto = new Produto();
            produto.IdProduto = Guid.NewGuid();

            Console.Write("Nome do Produto............: ");
            produto.Nome = Console.ReadLine();

            Console.Write("Preço do Produto...........: ");
            produto.Preco = decimal.Parse(Console.ReadLine());

            Console.Write("Quantidade.................: ");
            produto.Quantidade = int.Parse(Console.ReadLine());

            Console.Write("Nome da Categoria..........: ");
            produto.Categoria = (Categoria)Enum.Parse(typeof(Categoria), Console.ReadLine());

            produtoRepository.Inserir(produto);

            Console.WriteLine("PRODUTO ADICIONADO COM SUCESSO!");
        }

    }
}
