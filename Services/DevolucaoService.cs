/*
    4. Devolução de livros
        Atualização do status do livro como disponível.
        Cálculo de multa por atraso, se aplicável.*/
using System;

namespace TREINO.Services
{
    internal class DevolucaoService
    {

        //const e private, ou seja, não pode ser alterado e só pode ser usado dentro dessa classe.
        private const double valorMultaDiaria = 2.00;

        public void RealizarDevolucao(Emprestimo emprestimo)
        {
            emprestimo.DataDevolucaoReal = DateTime.Now;
            emprestimo.Devolvido = true;
            emprestimo.Livro.QuantidadeExemplares += 1;

            // Calcular multa se houver atraso
            if(emprestimo.DataDevolucaoReal > emprestimo.DataDevolucaoPrevista)
            {
                int diasAtraso = (emprestimo.DataDevolucaoReal.Value - emprestimo.DataDevolucaoPrevista).Days;
                
                emprestimo.Multa = diasAtraso * valorMultaDiaria;
            }
        }
    }
}
