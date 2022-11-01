using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.NBP;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Infrastructure.ExternalAPIs.NBP;

public partial class NBPClient : INBPClient
{
    private string _baseUrl = "http://api.nbp.pl/api/";
    private readonly HttpClient _httpClient;
    private readonly Lazy<JsonSerializerSettings> _settings;

    public NBPClient(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("NBPClient");
        _baseUrl = _httpClient.BaseAddress.ToString();
        _settings = new Lazy<JsonSerializerSettings>(() =>
        {
            var settings = new JsonSerializerSettings();
            UpdateJsonSerializerSettings(settings);
            return settings;
        });


    }

    protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }

    partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);

    public string BaseUrl
    {
        get { return _baseUrl; }
        set { _baseUrl = value; }
    }

    public async Task<EuExchangesData> GetAllPlnExchangeRates(CancellationToken cancellationToken)
    {
        var urlBuilder = new StringBuilder();
        urlBuilder.Append(_baseUrl).Append("/exchangerates/tables/A/?format=json");
        var client = _httpClient;
        using (var apiResponse = await client.GetAsync(urlBuilder.ToString(), cancellationToken))
        {
            if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var sc = await apiResponse.Content.ReadAsStringAsync(cancellationToken);
				if (!string.IsNullOrEmpty(sc)){
                    EuExchangesData deserialized = JsonConvert.DeserializeObject<EuExchangesData>(sc.Substring(1, sc.Length - 2));
                    return deserialized;
				}
			}
		}
		throw new Exception("Error");
	}

	public async Task<ExchangeCurrency> GetExchangeRateByCurrency(string requiredCurrencyCode, CancellationToken cancellationToken)
	{
        var urlBuilder = new StringBuilder();
        urlBuilder.Append(_baseUrl).Append($"/exchangerates/rates/A/{requiredCurrencyCode}/?format=json");
        var client = _httpClient;
        using (var apiResponse = await client.GetAsync(urlBuilder.ToString(), cancellationToken))
        {
            if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var sc = await apiResponse.Content.ReadAsStringAsync(cancellationToken);
                if (!string.IsNullOrEmpty(sc))
                {
                    //var settings = new JsonSerializerSettings
                    //{
                    //    NullValueHandling = NullValueHandling.Ignore,
                    //    MissingMemberHandling = MissingMemberHandling.Ignore
                    //};
                    ExchangeCurrency deserialized = JsonConvert.DeserializeObject<ExchangeCurrency>(sc/*, settings*/);
                    //Create Entity with all the fields, then automapper it to GetExchangeRateByCurrencyVm and return.
                    return deserialized;
                }
            }
        }
        throw new Exception("Error");
    }
}
