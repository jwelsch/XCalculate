using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

            var searchName = "\"" + bindingContext.FieldName + "\":";

            var searchStartIndex = body.IndexOf(searchName) + searchName.Length;

            var endBracketIndex = body.IndexOfMatchingBracket(searchStartIndex);

            var data = body.Substring(searchStartIndex, endBracketIndex - searchStartIndex + 1);

            var inputs = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);

            bindingContext.Result = ModelBindingResult.Success(inputs);

            return Task.CompletedTask;
        }
    }
}
