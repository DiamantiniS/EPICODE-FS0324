using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Diama_sHotel.Models;
using System.Threading.Tasks;

namespace Diama_sHotel.Binders
{
    public class ClienteModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            var value = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            try
            {
                var cliente = JsonConvert.DeserializeObject<Cliente>(value);
                bindingContext.Result = ModelBindingResult.Success(cliente);
            }
            catch (JsonException)
            {
                bindingContext.ModelState.TryAddModelError(modelName, "Invalid data.");
            }

            return Task.CompletedTask;
        }
    }
}
