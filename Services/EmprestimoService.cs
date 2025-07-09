
/*
3.Empréstimo de livros
        Registro de qual livro foi emprestado a qual usuário.
        Datas de empréstimo e de devolução previstas.

*/
using System;
using System.Globalization;
using TREINO.Entities;

namespace TREINO.Services
{
    internal class EmprestimoService
    {
        public Emprestimo RealizarEmprestimo(Livros livro, Usuarios usuario)
        {
            if(livro.QuantidadeExemplares <= 0)
            {
                throw new Exception("Livro não disponível para empréstimo.");
            }

            livro.QuantidadeExemplares -= 1;

            //Objeto empréstimo
            return new Emprestimo
            {
                Livro = livro,
                Usuario = usuario,
                DataEmprestimo = DateTime.Now,
                DataDevolucaoPrevista = DateTime.Now.AddDays(14),
            };
        }
    }
}

