using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FunkyDeploy.Services
{
    public interface IDtoService
    {
        Task<TModel> GetModelAsync<TModel>(HttpRequest request);
    }

    public class DtoService : IDtoService
    {
        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            Error = (sender, args) => args.ErrorContext.Handled = true
        };

        public async Task<TModel> GetModelAsync<TModel>(HttpRequest request)
        {
            var content = await new StreamReader(request.Body).ReadToEndAsync();
            if (string.IsNullOrWhiteSpace(content))
            {
                return default(TModel);
            }

            var model = JsonConvert.DeserializeObject<TModel>(content, _serializerSettings);
            return model;
        }
    }
}
