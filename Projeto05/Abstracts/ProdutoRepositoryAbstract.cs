﻿using System;
using System.Collections.Generic;
using System.Text;
using Projeto05.Entities; //importando
using Projeto05.Entities.Enums; //importando

namespace Projeto05.Abstracts
{
    public abstract class ProdutoRepositoryAbstract
    {
        //declarando atributos na classe abstrata
        //protected -> acesso por meio de herança
        protected List<Produto> listagemDeProdutos;

        //Método construtor
        //utilizado quando uma classe é instanciada (new)

        public ProdutoRepositoryAbstract()
        {
            //inicializando o atributo lista de produtos
            listagemDeProdutos = new List<Produto>();
        }

        //métodos abstratos..

        public abstract void Inserir(Produto produto);

        public abstract void Atualizar(Produto produto);

        public abstract void Excluir(Produto produto);

        public abstract List<Produto> Consultar();

        public abstract List<Produto> Consultar(string nome);

        public abstract List<Produto> Consultar(decimal precoMin, decimal precoMax);

        public abstract Produto ObterPorId(Guid idProduto);
    }
}
