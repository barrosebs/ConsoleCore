using System.Globalization;
using TesteDevFullStack.Enum;
using TesteDevFullStack.Model;

namespace TesteDevFullStack.Service
{
    public class CreditoService
    {
        CreditoModel model = new CreditoModel();


        public CreditoService(CreditoModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Converte a string Data em DateTime
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DateTime converteData(string data)
        {
            try
            {
                 DateTime _data = DateTime.ParseExact(data, "ddMMyyyy", new CultureInfo("en-us", false));
                 return _data;

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error:" + ex.Message);
            }
            return DateTime.MinValue;
        }
        public override string ToString()
        {
            return "\n Valor do Empréstimo: " + model.Valor.ToString("F2") + "\n Tipo: " + model.Tipo + "\n Quantidade de Parcelas: " + model.QtdParcelas + 
                    "\n Data do primeiro vencimento: " + model.DataPrimeiroVencimento.ToString("dd/MM/yyyy" + "\n VALOR TOTAL: " +model.ValorTotal.ToString("F2") + "\n VALOR DE JUROS: " + model.ValorJuros.ToString("F2"));
        }

        public CreditoModel validaCredito(CreditoModel model)
        {
            double taxaJuros = 0;
            if (model.Valor > 10 && model.Valor <= 1000000)
            {

                if (((int)CreditoEnum.Direto) == model.Tipo)
                {
                    taxaJuros = 0.02 * model.QtdParcelas;
                    model.ValorTotal = model.Valor + (model.Valor * Math.Pow((taxaJuros) + 1, (model.QtdParcelas)) * taxaJuros) / (Math.Pow(taxaJuros + 1, (model.QtdParcelas)) - 1);
                    model.ValorJuros = model.ValorTotal - model.Valor;
                    return model;
                }
                else if (CreditoEnum.Consignado == model.Tipo)
                {
                    taxaJuros = 0.01 * model.QtdParcelas;
                    model.ValorTotal = model.Valor + (model.Valor * Math.Pow((taxaJuros) + 1, (model.QtdParcelas)) * taxaJuros) / (Math.Pow(taxaJuros + 1, (model.QtdParcelas)) - 1);
                    model.ValorJuros = model.ValorTotal - model.Valor;
                    return model;
                }
                else if (CreditoEnum.PessoaJuridica == model.Tipo)
                {
                    taxaJuros = 0.05 * model.QtdParcelas;
                    model.ValorTotal = model.Valor + (model.Valor * Math.Pow((taxaJuros) + 1, (model.QtdParcelas)) * taxaJuros) / (Math.Pow(taxaJuros + 1, (model.QtdParcelas)) - 1);
                    model.ValorJuros = model.ValorTotal - model.Valor;
                    return model;

                }
                else if (CreditoEnum.PessoaFisica == model.Tipo)
                {
                    taxaJuros = 0.03 * model.QtdParcelas;
                    model.ValorTotal = model.Valor + (model.Valor * Math.Pow((taxaJuros) + 1, (model.QtdParcelas)) * taxaJuros) / (Math.Pow(taxaJuros + 1, (model.QtdParcelas)) - 1);
                    model.ValorJuros = model.ValorTotal - model.Valor;
                    return model;

                }
                else if (CreditoEnum.Imobiliario == model.Tipo)
                {
                    taxaJuros = 0.09 * model.QtdParcelas;
                    model.ValorTotal = model.Valor + (model.Valor * Math.Pow((taxaJuros) + 1, (model.QtdParcelas)) * taxaJuros) / (Math.Pow(taxaJuros+1, (model.QtdParcelas))-1);
                    model.ValorJuros = model.ValorTotal - model.Valor;
                    return model;

                }
                else
                {
                    model.Valor = -1;
                    return model;
                }
            }
            return null;
        }
    }
}
