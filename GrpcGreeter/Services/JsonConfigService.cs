using Grpc.Core;
using GrpcGreeter;

namespace GrpcGreeter.Services
{
    public class JsonConfigService : JsonConfig.JsonConfigBase
    {

        private readonly ILogger<JsonConfigService> _logger;
        private readonly IWebHostEnvironment _environment;
        public JsonConfigService(ILogger<JsonConfigService> logger,
            IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public override Task<JsonReply> SendJsonConfig(JsonRequest request, ServerCallContext context)
        {
            var storagePath = Path.Combine(_environment.ContentRootPath, "Storage");
            var configPath = Path.Combine(storagePath, request.Id, "config.json");
            var dataPath = Path.Combine(storagePath, request.Id, "data.json");
            var configJson =  File.ReadAllText(configPath);
            var dataJson =  File.ReadAllText(dataPath);

            //var payload = JObject.Parse(dataJson);
            //var config = JObject.Parse(configJson);
            return Task.FromResult(new JsonReply
            {
                ConfigJson = configJson.ToString(),
                PayloadJson = dataJson.ToString()
            });

        }
    }
}
