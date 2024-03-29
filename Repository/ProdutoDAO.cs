﻿using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class ProdutoDAO : IRepository<Produto>
    {
        //var somente leitura
        private readonly Context _context;
        public ProdutoDAO(Context context)
        {
            //depende do contexto para funcionar
            _context = context;            
        }
        public bool Cadastrar(Produto p)
        {
            //faz a validação antes de salvar
            if (BuscarProdutoPorNome(p) == null)
            {
                _context.Produtos.Add(p);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        //verifica se existe um produto já cadastrado
        public Produto BuscarProdutoPorNome(Produto p)
        {
            return _context.Produtos.FirstOrDefault(x => x.Nome == p.Nome);
        }
        public Produto BuscarPorId(int? id)
        {
            return _context.Produtos.Find(id);            
        }
        //id pode vir nulo
        public bool Remover(int? id)
        {
            if(id == null)
            {
                return false;
            }
            _context.Produtos.Remove(BuscarPorId(id));
            _context.SaveChanges();
            return true;                       
        }
        public void Alterar(Produto p)
        {
            _context.Produtos.Update(p);
            _context.SaveChanges();
        }

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
        public List<Produto> ListarPorCategoria(int? id)
        {
            //inclui a Categoria que está dentro de Produtos
            return _context.Produtos.Include(x => x.Categoria).
                Where(x => x.Categoria.CategoriaId == id).ToList();
        }
    }
}
