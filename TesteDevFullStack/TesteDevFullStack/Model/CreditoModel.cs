using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDevFullStack.Enum;

namespace TesteDevFullStack.Model
{
    public class CreditoModel
    {
        public double Valor { get; set; }
        public CreditoEnum Tipo { get; set; }
        public int QtdParcelas { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
        public double ValorTotal { get; set; }
        public double ValorJuros { get; set; }
        public string StatusCredito { get; set; }
    }
}
