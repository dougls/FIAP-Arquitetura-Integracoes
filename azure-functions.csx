#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("A função do gatilho HTTP em C# está processando uma solicitação.");

    string apiUrl = "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=brl"; // URL da API para obter o preço do Bitcoin em BRL

    using (var httpClient = new HttpClient())
    {
    string responseJson = await httpClient.GetStringAsync(apiUrl);

    dynamic responseData = JsonConvert.DeserializeObject(responseJson);

    decimal btcPrice = responseData.bitcoin.brl;

    return new OkObjectResult(new {precoBTC = btcPrice}); // Retorna o preço do Bitcoin em BRL como resposta
    }
}
