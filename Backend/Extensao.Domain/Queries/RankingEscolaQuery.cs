using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Text;

namespace Extensao.Domain.Queries
{
    public class RankingEscolaQuery
    {
        public string NomeEscola { get; set; }
        public string NomeTipoEscola { get; set; }
        public double MediaNota { get; set; }
        public string TemEducacaoNee { get; set; }

    }
}
