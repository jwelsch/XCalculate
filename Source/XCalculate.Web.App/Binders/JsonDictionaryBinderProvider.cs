using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;

namespace XCalculate.Web.App.Binders
{
    public class JsonDictionaryBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(Dictionary<string, string>))
            {
                return new BinderTypeModelBinder(typeof(JsonDictionaryBinder));
            }

            return null;
        }
    }
}
