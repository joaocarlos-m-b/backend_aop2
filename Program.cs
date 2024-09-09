using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BACKEND_AOP2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Iniciando solicitação...");

            // Criando uma instância do HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Configurando a URL da solicitação
                    string url = "https://brasilapi.com.br/api/taxas/v1";

                    // Enviando uma solicitação GET
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Verificando se a resposta foi bem-sucedida
                    if (response.IsSuccessStatusCode)
                    {
                        // Lendo o conteúdo da resposta como string
                        string responseData = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Resposta recebida com sucesso:");
                        Console.WriteLine(responseData);
                    }
                    else
                    {
                        Console.WriteLine("Erro na solicitação: " + response.StatusCode);
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Erro de requisição: " + e.Message);
                }
            }

            Console.WriteLine("Finalizando solicitação...");
            
        }
    }
}
