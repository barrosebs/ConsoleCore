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

        public CreditoModel validaCredito(int tipo, double valor, int qtd, string data)
        {
            if (valor > 10 && valor <= 1000000)
            {
                double valorCredito = valor;
                int qtdCredito = qtd;
                DateTime date = DateTime.Parse(data);

                if (((int)CreditoEnum.Direto) == tipo)
                {
                    model.Valor = (0.02 * 100) * valor;
                    return model;
                }
                else if (((int)CreditoEnum.Consignado) == tipo)
                {
                    model.Valor = (0.01 * 100) * valor;
                    return model;
                }
                else if (((int)CreditoEnum.PessoaJuridica) == tipo)
                {
                    model.Valor = (0.05 * 100) * valor;
                    return model;

                }
                else if (((int)CreditoEnum.PessoaFisica) == tipo)
                {
                    model.Valor = (0.03 * 100) * valor;
                    return model;

                }
                else if (((int)CreditoEnum.Imobiliario) == tipo)
                {
                    model.Valor = (0.09 * 100) * valor;
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
        public override string ToString()
        {
            return "Valor do Empréstimo: " + model.Valor.ToString("F2") + ", Tipo: " + model.Tipo + ", Quantidade de Parcelas: " + model.QtdParcelas + ", Data do primeiro vencimento: " + model.DataPrimeiroVencimento;
        }
    }
}
