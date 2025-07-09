
using System;

namespace TREINO.Entities
{
    internal class Livros
    {
        public string Titulo{ get; private set; }
        public string Autor{ get; set; }
        public string Editora { get; set; }
        public int Ano { get; set; }
        public string Categoria { get; set; }
        public int QuantidadeExemplares { get; set; }

        public Livros(string titulo, string autor, string editora, int ano,string categoria, int quantidadeExemplares) 
        {
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Ano = ano;
            Categoria = categoria;
            QuantidadeExemplares = quantidadeExemplares;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) { 
                return false; 
            }
            
            Livros outro = (Livros)obj;

            return (Titulo == outro.Titulo);
        }
        public override int GetHashCode()
        {
            return Titulo.GetHashCode();
        }

        public override string ToString()
        {
            return $"\nTítulo do livro: {Titulo}\n" +
                $"Autor do livro: {Autor}\n" +
                $"Editora do livro: {Editora}\n" +
                $"Ano do livro: {Ano}\n" +
                $"Categoria do livro: {Categoria}\n" +
                $"Quantidade de exemplares do livro: {QuantidadeExemplares:F0} exemplares\n\n";
        }
    }
}
