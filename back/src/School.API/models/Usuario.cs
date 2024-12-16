using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.API.models
{
    public class Usuario
    {
        public Usuario() { }
        public Usuario(int id, string nome, string sobrenome, string email, DateTime dataNascimento, int escolaridade) 
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Email = email;
            this.DataNascimento = dataNascimento;
            this.Escolaridade = escolaridade;
   
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Escolaridade { get; set; }
    }
}