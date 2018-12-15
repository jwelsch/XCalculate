using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace XCalculate.Web.App.Binders
{
    public class JsonDictionaryBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //bindingContext.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);

            var body = string.Empty;

            using (var reader = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                body = reader.ReadToEnd();
            }

            // Remove the last '}', then the first '{', finally the name of the field plus the surrounding '"' and the ':'.
            body = body.Substring(0, body.Length - 1).TrimStart('{').Substring(bindingContext.FieldName.Length + 3);

            var inputs = JsonConvert.DeserializeObject<Dictionary<string, string>>(body);

            bindingContext.Result = ModelBindingResult.Success(inputs);

            return Task.CompletedTask;
        }
    }
}
