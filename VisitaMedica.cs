
using System;

namespace MP09.UF01.P01.VisitaMedica.model.domain
{
    public class VisitaMedica
    {
        public string NomPacient { get; set; }
        public string NomMetge { get; set; }
        public DateTime Data { get; set; }
        public string Diagnosi { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"VisitaMedica [NomPacient={NomPacient}, NomMetge={NomMetge}, Data={Data}, Diagnosi={Diagnosi}]";
        }
    }
}


