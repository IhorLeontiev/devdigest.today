﻿using System;
using System.Linq;
using Core.CognitiveServices;
using Core.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace Core
{
    public class LanguageAnalyzer
    {
        private readonly IRestClient _client;
        private readonly ILogger _logger;

        public LanguageAnalyzer(string key, ILogger logger)
        {
            _logger = logger;

            _client = new RestClient("https://westeurope.api.cognitive.microsoft.com/text/analytics/v2.0");

            _client.AddDefaultHeader("Ocp-Apim-Subscription-Key", key);
            _client.AddDefaultHeader("Content-Type", "application/json");
            _client.AddDefaultHeader("Accept", "application/json");
        }

        public string GetTextLanguage(string text)
        {
            var request = new RestRequest("languages", Method.POST);

            request.RequestFormat = DataFormat.Json;

            var body = new Query
            {
                Documents = new[] {new RequestDocument(Guid.NewGuid().ToString(), text)}
            };

            var json = JsonConvert.SerializeObject(body, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            request.AddParameter("application/json", json, ParameterType.RequestBody);

            try
            {
                IRestResponse response = _client.Execute(request);
                var apiResponse = JsonConvert.DeserializeObject<Response>(response.Content);
                var language = apiResponse.Documents?.Select(o => o.DetectedLanguages).FirstOrDefault()
                    ?.FirstOrDefault();
                return language?.Iso6391Name;
            }
            catch(Exception ex)
            {
                _logger.Write(LogLevel.Error, $"Error in `{nameof(GetTextLanguage)}` method", ex);
                return string.Empty;
            }
        }
    }
}