using SneakerShop.Core.Enums.Web;
using SneakerShop.Core.Models.Web;
using System.Linq.Expressions;

namespace SneakerShop.Core.Extensions
{
    public static class EntityExtensions
    {

        /// <summary>
        /// Применить пагинацию
        /// </summary>
        public static IQueryable<T> WithPagination<T>(this IQueryable<T> source, BaseListParams baseParam)
        {
            if (source == null || baseParam == null || baseParam.PageNumber < 0 || baseParam.RowsCount < 0)
                return source;

            return source
                .Skip((baseParam.PageNumber - 1) * baseParam.RowsCount)
                .Take(baseParam.RowsCount);
        }

        /// <summary>
        /// Отсортировать данные
        /// </summary>
        public static IQueryable<T> WithOrdering<T>(this IQueryable<T> source, BaseListParams baseParam)
        {
            if (source == null || baseParam?.OrderBy == null)
                return source;

            foreach (var ordering in baseParam.OrderBy)
            {
                var parameterExpression = Expression.Parameter(typeof(T), "x");
                var keySelector = Expression.Lambda<Func<T, object>>(
                    Expression.Convert(ReflectionUtil.GetPropertyForExpression(parameterExpression, ordering.Key), typeof(object)),
                    new ParameterExpression[1] { parameterExpression });

                if (ordering.Value)
                    source = source.OrderBy(keySelector);
                else
                    source = source.OrderByDescending(keySelector);
            }

            return source;
        }

        /// <summary>
        /// Применить фильтрацию
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="baseParam"></param>
        /// <returns></returns>
        public static IQueryable<T> WithFilter<T>(this IQueryable<T> source, BaseListParams baseParam)
        {
            if (source == null || baseParam?.Filters == null)
                return source;

            foreach (var filter in baseParam.Filters)
            {
                if (filter.Operator == ComplexFilterOperators.All)
                    continue;

                ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "x");
                Expression expression = filter.ReadComplexFilterExpression(parameterExpression);
                if (expression != null)
                {
                    source = source.Where(Expression.Lambda<Func<T, bool>>(expression, new ParameterExpression[1] { parameterExpression }));
                }
            }
            return source;
        }

    }
}