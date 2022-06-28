// See https://aka.ms/new-console-template for more information
using System.Globalization;
using TesteDevFullStack.Enum;
using TesteDevFullStack.Model;
using TesteDevFullStack.Service;
CreditoModel model = new CreditoModel();

CreditoService service = new CreditoService(model);

Console.WriteLine("Entre com o valor de Crédito");
Console.Write("Valor:");
double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
Console.WriteLine("Informe o tipo de Crédito:\n 0 Direto;\n 1 Consignado;\n 2 Pessoa Jurídica;\n 3 Pessoa Física;\n 4 Imobiliário");
Console.Write("Tipo:");
int tipo = int.Parse(Console.ReadLine()); 
if (tipo >= 0 && tipo <=4)
{
    model.Valor = service.validaCredito(tipo,valor);
    model.Tipo = tipo;
}


Console.WriteLine(service.ToString());
Console.ReadLine();