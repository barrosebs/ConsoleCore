// See https://aka.ms/new-console-template for more information
using System.Globalization;
using TesteDevFullStack.Enum;
using TesteDevFullStack.Model;
using TesteDevFullStack.Service;
CreditoModel model = new CreditoModel();

CreditoService service = new CreditoService(model);
Console.Write("\n\n===========================================================\nSISTEMA DE CRÉDITO = SC\n===========================================================\n");

int tipo = -1;
bool valida = false;
string mensagem = "";
do
{
    Console.WriteLine("Entre com o valor de Crédito");
    Console.Write("Valor: ");
    double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    if (valor >= 10 && valor < 1000000)
    {
        model.Valor = valor;
        valida = true;

        Console.WriteLine("Informe o tipo de Crédito:\n 0 Direto;\n 1 Consignado;\n 2 Pessoa Jurídica;\n 3 Pessoa Física;\n 4 Imobiliário");
        Console.Write("Tipo: ");
        tipo = int.Parse(Console.ReadLine());
        if (tipo >= 0 && tipo <= 4)
        {
            foreach (int _tipo in (CreditoEnum[])Enum.GetValues(typeof(CreditoEnum)))
            {
                if (_tipo.Equals(tipo))
                {
                    model.Tipo = ((CreditoEnum)_tipo);
                }
            }
            valida = true;

            Console.WriteLine("Qual a quantidade de parcelas? ");
            Console.Write("Quantidade: ");
            int qtdParcelas = int.Parse(Console.ReadLine());
            if (qtdParcelas >= 5 && qtdParcelas <= 72)
            {
                model.QtdParcelas = qtdParcelas;
                valida = true;
                Console.WriteLine("Qual a data do primeiro vencimento?");
                Console.Write("DATA: (formato = DDMMAAAA, sem barra ou traços) ");
                DateTime data = service.converteData(Console.ReadLine());

                DateTime diaMin = DateTime.Now.AddDays(15);
                DateTime diaMax = DateTime.Now.AddDays(40);

                if (data >= diaMin && data <= diaMax)
                {
                    model.DataPrimeiroVencimento = data;
                    model = service.validaCredito(model);
                    model.StatusCredito = "APROVADO";
                    Console.Write("\n\n===========================================================\nDADOS DO EMPRÉSTIMO\n===========================================================\n");
                    Console.WriteLine(service.ToString());
                }
                else
                {
                    valida = false;
                    model.StatusCredito = "REPROVADO!";
                    mensagem = "\nVencimento da Primeira parcela esta fora do limite mínimo(hoje+15) e máximo(hoje+40)";
                }
            }
            else
            {
                valida = false;
                mensagem = "ATENÇÂO: quantidade mínima é de 5x e máximo de 72x ";
                model.StatusCredito = "REPROVADO";
            }
        }
        else
        {
            valida = false;
            mensagem = "Informe a opção de crédito conforme as apresentadas! ";
            model.StatusCredito = "REPROVADO";
        }
    }
    else
    {
        valida = false;
        mensagem = "Valor informado não esta dentro do limite mínimo e máximo(100.000,00).";
        model.StatusCredito = "REPROVADO";
    }
    Console.WriteLine("STATUS DO CREDITO: " + model.StatusCredito);
    Console.WriteLine(mensagem);
} while (valida == false);


Console.Write("\n==============OBRIGADO POR USAR NOSSO SISTEMA!=============");
Console.ReadLine();





