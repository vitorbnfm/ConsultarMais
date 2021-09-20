using System;


namespace Consultar+.Models
{
    public class Medico
    {  
        
        public Medico() => CriadoEm = DateTime.Now;

        //Atributos ou propriedades
        public int Id { get; set; }
        public int CRM  { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }


        public DateTime CriadoEm { get; set; }
        
    }
}