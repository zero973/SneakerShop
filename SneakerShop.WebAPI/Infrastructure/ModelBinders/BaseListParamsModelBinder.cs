using Microsoft.AspNetCore.Mvc.ModelBinding;
using SneakerShop.Core.Models.Web;

namespace SneakerShop.WebAPI.Infrastructure.ModelBinders
{
    /// <summary>
    /// Парсер для <see cref="BaseListParams"/>
    /// </summary>
    public class BaseListParamsModelBinder : IModelBinder
    {

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var queryPageNumber = bindingContext.ValueProvider.GetValue("PageNumber").FirstValue;
            var queryRowsCount = bindingContext.ValueProvider.GetValue("RowsCount").FirstValue;
            var queryOrderBy = (bindingContext.ValueProvider as IEnumerableValueProvider).GetKeysFromPrefix("OrderBy");
            var queryFilters = bindingContext.ValueProvider.GetValue("Filters").FirstValue;

            var pageNumber = Convert.ToInt32(queryPageNumber);
            var rowsCount = Convert.ToInt32(queryRowsCount);

            var orderBy = new Dictionary<string, bool>();
            if (queryOrderBy.Any())
                orderBy = queryOrderBy.ToDictionary(x => x.Key, x => Convert.ToBoolean(bindingContext.ValueProvider.GetValue(x.Value).FirstValue));

            var filters = new List<ComplexFilter>();
            if (queryFilters?.Length > 2)
                filters = System.Text.Json.JsonSerializer.Deserialize<List<ComplexFilter>>(queryFilters);

            var result = new BaseListParams() 
            {
                PageNumber = pageNumber, 
                RowsCount = rowsCount,
                OrderBy = orderBy,
                Filters = filters
            };

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }

    }
}