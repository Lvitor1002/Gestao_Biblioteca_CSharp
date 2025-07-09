


using System;
using TREINO.Entities;


namespace TREINO.Services
{
    internal class Emprestimo
    {
        public Livros Livro { get; set; }
        public Usuarios Usuario{ get; set; }
        public DateTime DataEmprestimo{ get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime? DataDevolucaoReal { get; set; }
        public bool Devolvido{ get; set; }
        public double Multa{ get; set; }

        public override string ToString()
        {
            return $"\nLivro: {Livro.Titulo}\n" +
                $"Usuário: {Usuario.Nome}\n" +
                $"Empréstimo: {DataEmprestimo:dd/MM/yyyy}\n" +
                $"Devolução prevista: {DataDevolucaoPrevista:dd/MM/yyyy}\n" +
                $"Devolvido: {(Devolvido ? "Sim" : "Não")}\n" +
                $"Multa: R${Multa:F2}\n\n";
        }
    }
}
