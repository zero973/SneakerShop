using Microsoft.AspNetCore.Mvc.ModelBinding;
using SneakerShop.Core.Models.Web;
using SneakerShop.WebAPI.Infrastructure.ModelBinders;

namespace SneakerShop.WebAPI.Infrastructure.ModelBinderProviders
{
    public class BaseListParamsModelBinderProvider : IModelBinderProvider
    {

        private readonly IModelBinder binder = new BaseListParamsModelBinder();

        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(BaseListParams) ? binder : null;
        }
    }
}