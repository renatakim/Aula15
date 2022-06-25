

using System.Globalization;

namespace Exercicio15
{
    public class Exercicio
    {
        public Dictionary<Moeda, Cambio> dicCambios = new Dictionary<Moeda, Cambio>()
        {
            { Moeda.Real, new Cambio() { Descricao = "Real (BRL)", Taxa = 1, CultureInfo = "pt-BR"} },
            { Moeda.Dolar, new Cambio() { Descricao = "Dólar dos Estados Unidos (USD)", Taxa = 4.50M, CultureInfo = "us-US" } },
            { Moeda.Euro, new Cambio() { Descricao = "Euro (EUR)", Taxa = 6.20M, CultureInfo = "en-GB" } },
            { Moeda.Iene, new Cambio() { Descricao = "Iene (JPY)", Taxa = 0.052M, CultureInfo = "ja-JP" } },
            { Moeda.Libra, new Cambio() { Descricao = "Libra Esterlina (GBP)", Taxa = 6.95M, CultureInfo = "fr-FR" } },
            { Moeda.Won, new Cambio() {Descricao = "Won Sul Coreano (KRW)", Taxa = 0.078M, CultureInfo = "ko-KO"} }
        };

        public void Start()
        {
            Console.WriteLine("Converter de : ");
            MontarMenu();
            Moeda conversaoDe = Enum.Parse<Moeda>(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine("Converter para : ");
            MontarMenu();
            Moeda conversaoPara = Enum.Parse<Moeda>(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine("Digite o valor que deseja converter: ");
            decimal valorParaConverter = decimal.Parse(Console.ReadLine());

            decimal valorConvertido = 0;

            if (conversaoDe == Moeda.Real)
            {
                valorConvertido = Conversao.ConverterParaOutraMoeda(valorParaConverter, dicCambios[conversaoPara].Taxa);
            }
            else
            {
                decimal valorReal = Conversao.ConverterParaReal(valorParaConverter, dicCambios[conversaoDe].Taxa);
                valorConvertido = Conversao.ConverterParaOutraMoeda(valorReal, dicCambios[conversaoPara].Taxa);
            }

            Console.WriteLine("");
            Console.WriteLine($"O valor convertido é {valorConvertido.ToString("C", CultureInfo.CreateSpecificCulture(dicCambios[conversaoPara].CultureInfo))}");
        }
        public void MontarMenu()
        {
            foreach (var item in dicCambios)
            {
                Console.WriteLine($"{ (int) item.Key } - {item.Value.Descricao}");
            }

            Console.Write("> ");
        }
    }
}
