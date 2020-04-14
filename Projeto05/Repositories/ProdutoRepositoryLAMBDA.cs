using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Projeto05.Entities;
using Projeto05.Abstracts;
using Projeto05.Entities.Enums;

namespace Projeto05.Repositories
{
    public class ProdutoRepositoryLAMBDA : ProdutoRepositoryAbstract
    {

        public override void Inserir(Produto produto)
        {
            listagemDeProdutos.Add(produto);
        }

        public override void Atualizar(Produto produto)
        {
            //buscar o produto dentro da lista atraves do id..
            var item = listagemDeProdutos
                        .Where(p => p.IdProduto == produto.IdProduto)
                        .FirstOrDefault();

            //verificar se algum produto foi encontrado
            if (item != null)
            {
                item.Nome = produto.Nome;
                item.Preco = produto.Preco;
                item.Quantidade = produto.Quantidade;
                item.Categoria = produto.Categoria;
            }
            else
            {
                throw new Exception("Erro. Produto não foi encontrado.");
            }
        }

        public override void Excluir(Produto produto)
        {
            listagemDeProdutos.Remove(produto);
        }

        public override List<Produto> Consultar()
        {
            return listagemDeProdutos
                    .OrderBy(p => p.Nome)
                    .ToList();
        }

        public override List<Produto> Consultar(string nome)
        {
            return listagemDeProdutos
                    .Where(p => p.Nome.Contains(nome))
                    .OrderBy(p => p.Nome)
                    .ToList();
        }

        public override List<Produto> Consultar(decimal precoMin, decimal precoMax)
        {
            return listagemDeProdutos
                    .Where(p => p.Preco >= precoMin && p.Preco <= precoMax)
                    .OrderByDescending(p => p.Preco)
                    .ToList();
        }

        public override Produto ObterPorId(Guid idProduto)
        {
            return listagemDeProdutos
                    .Where(p => p.IdProduto == idProduto)
                    .FirstOrDefault();
        }

        public override List<Produto> Consultar(Categoria categoria)
        {
            return listagemDeProdutos
                    .Where(p => p.Categoria == categoria)
                    .OrderBy(p => p.Nome)
                    .ToList();
        }
    }
}
