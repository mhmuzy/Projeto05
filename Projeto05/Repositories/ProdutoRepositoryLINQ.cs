﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Projeto05.Abstracts;
using Projeto05.Entities;
using Projeto05.Entities.Enums;

namespace Projeto05.Repositories
{
    public class ProdutoRepositoryLINQ : ProdutoRepositoryAbstract
    {

        public override void Inserir(Produto produto)
        {
            //adicionar o produto na lista
            listagemDeProdutos.Add(produto);
        }

        public override void Atualizar(Produto produto)
        {
            //procurar dentro da lista o produto através do id..
            var query = from p in listagemDeProdutos
                        where p.IdProduto == produto.IdProduto
                        select p;

            //buscar o primeiro registro obtido da consulta acima..
            var item = query.FirstOrDefault();

            //verificar se a consulta retornou algum elemento
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
            //excluir o produto da lista
            listagemDeProdutos.Remove(produto);

        }

        public override List<Produto> Consultar()
        {
            //retornar todos os produtos da lista em ordem alfabetica
            var query = from p in listagemDeProdutos
                        orderby p.Nome ascending
                        select p;

            //retornar uma lista de produtos
            return query.ToList();

        }

        public override List<Produto> Consultar(string nome)
        {
            //retornar todos os produtos da lista em ordem alfabética
            var query = from p in listagemDeProdutos
                        where p.Nome.Contains(nome)
                        orderby p.Nome ascending
                        select p;

            //retornar uma lista de produtos
            return query.ToList();
        }

        public override List<Produto> Consultar(decimal precoMin, decimal precoMax)
        {
            //retornar todos os produtos da lista em ordem alfabética
            var query = from p in listagemDeProdutos
                        where p.Preco >= precoMin && p.Preco <= precoMax
                        orderby p.Preco descending
                        select p;

            //retornar uma lista de produtos
            return query.ToList();
        }

        public override Produto ObterPorId(Guid idProduto)
        {
            var query = from p in listagemDeProdutos
                        where p.IdProduto == idProduto
                        select p;

            //retornar o primeiro registro encontrado
            //ou null se nenhum for encontrado
            return query.FirstOrDefault();
        }

        public override List<Produto> Consultar(Categoria categoria)
        {
            var query = from p in listagemDeProdutos
                        where p.Categoria == categoria
                        orderby p.Categoria ascending
                        select p;

            return query.ToList();
        }
    }
}
