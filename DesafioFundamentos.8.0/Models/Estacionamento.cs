using System.Diagnostics.Contracts;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        private List<DateTime> horarios = new List<DateTime>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // *IMPLEMENTE AQUI*
            Console.WriteLine("ESTACIONAR VEICULO \n\nDigite a placa do veículo para estacionar:");
            //Pega valor do usuário e adciiona na lista
            //Também limpa a tela 
            string placa = Console.ReadLine();
            // Verifica se o veiculo já foi cadastrado para evitar erro ao remover valores iguais da lista
            if (!veiculos.Contains( placa)){

                veiculos.Add(placa);
                horarios.Add(DateTime.Now);
                Console.Clear();
                Console.WriteLine($"Veiculo com placa {placa} adicionado com sucesso");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nPlaca de veiculo já estacionado \nTente novamente");
                AdicionarVeiculo();

            }
            
                    
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine();
            Console.Clear();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()) && horarios.Count != 0)
            {
                int ndexDoCarro = veiculos.IndexOf(placa);
                TimeSpan horas = DateTime.Now.Subtract(horarios[ndexDoCarro]);
                decimal valorTotal =  ((int)horas.TotalSeconds) * precoPorHora + precoInicial; // Estou usando segundos para o resultado dar um valor alto no fim mas deve ser usado TotalHours

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                Console.WriteLine($"\n\nTotal de veiculos ainda estacionados: {veiculos.Count}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:\n");
                // *IMPLEMENTE AQUI*
            
            
            for (int i = 0; i < veiculos.Count; i++)
            {
                Console.WriteLine($"Veiculo placa: {veiculos[i]} estacionado em: {horarios[i]}");

            }
                
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
