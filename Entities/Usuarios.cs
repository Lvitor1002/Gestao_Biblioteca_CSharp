using System;
using System.Collections.Generic;

namespace TREINO.Entities
{
    internal class Usuarios
    {
        public string Nome{ get; set; }
        public int Matricula { get; private set; }
        public string Email { get; set; }
        public int Telefone { get; set; }

        public Usuarios(string nome, int matricula, string email, int telefone)
        {
            Nome = nome;
            Matricula = matricula;
            Email = email;
            Telefone = telefone;
        }


        //Comparação de igualdade para os métodos de editar
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()){
                return false; 
            }
            
            Usuarios outra = (Usuarios)obj;

            return Matricula == outra.Matricula;
        }
        public override int GetHashCode()
        {
            return Matricula.GetHashCode();
        }


        public override string ToString()
        {
            return $"\nNome do usuário: {Nome}\n" +
                $"Matricula do usuário: {Matricula}\n" +
                $"Email do usuário: {Email}\n" +
                $"Telefone do usuário: {Telefone}\n\n";
        }
    }
}
