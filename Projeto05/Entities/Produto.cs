using System;
using System.Collections.Generic;
using System.Text;
using Projeto05.Entities.Enums; //importando

namespace Projeto05.Entities
{
    public class Produto
    {
        //propriedades -> prop + 2x[tab]

        public Guid IdProduto { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        public Categoria Categoria { get; set; } //Associação
    }
}
