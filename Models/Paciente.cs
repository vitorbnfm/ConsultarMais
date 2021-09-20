using System;


namespace Consultar+.Models;
{
    public class Paciente
    {
        public Paciente() => CriadoEm = DateTime.Now;

        //Atributos ou propriedades
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public int Celular { get; set; }
        public string Email { get; set; }

        public DateTime CriadoEm { get; set; }


    }
}