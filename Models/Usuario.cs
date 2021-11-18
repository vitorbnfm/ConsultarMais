using System;

namespace Consultar.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public string Token { get; set; }

        public override string ToString() =>
            $"Nome: {Nome} | Login: {Login} | Senha: {Senha}";
    }
}