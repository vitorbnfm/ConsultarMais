using System;

namespace Consultar.Models
{
    public class Consulta
    {

        public Consulta() => CriadoEm = DateTime.Now;
        public int Id { get; set; }
        public string DataConsulta { get; set; }
        public Medico Medico { get; set; }
        public int MedicoId { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public DateTime CriadoEm { get; set; }
    }

}