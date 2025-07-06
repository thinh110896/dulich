using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Tourism.Shared.Models;

namespace Tourism.Shared;

public static class QueryableHelper
{
    public static async Task<PagedResult<T>> GetPagedListAsync<T>(
        this IQueryable<T> query,
        PagedRequest request,
        CancellationToken cancellationToken) where T : class
    {

        // Áp dụng tìm kiếm chung
        if (!string.IsNullOrEmpty(request.Search))
        {
            var param = Expression.Parameter(typeof(T), "x");
            // Duyệt tất cả các property kiểu string
            var searchExpressions = typeof(T).GetProperties()
                .Where(p => p.PropertyType == typeof(string))
                .Select(p =>
                {
                    var property = Expression.Property(param, p);
                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    var searchValue = Expression.Constant(request.Search, typeof(string));
                    return Expression.Call(property, containsMethod!, searchValue);
                })
                .ToList();


            if (searchExpressions.Any())
            {
                Expression searchExpression = searchExpressions.First();
                foreach (var expr in searchExpressions.Skip(1))
                {
                    searchExpression = Expression.OrElse(searchExpression, expr);
                }

                var lambda = Expression.Lambda<Func<T, bool>>(searchExpression, param);
                query = query.Where(lambda);
            }
        }

        // Áp dụng sắp xếp
        if (!string.IsNullOrEmpty(request.SortColumn))
        {
            var param = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(param, request.SortColumn);
            var lambda = Expression.Lambda(property, param);
            string methodName = request.IsDescending ? "OrderByDescending" : "OrderBy";

            var method = typeof(Queryable).GetMethods()
                .First(m => m.Name == methodName && m.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), property.Type);

            query = (IQueryable<T>)method.Invoke(null, new object[] { query, lambda })!;
        }

        // Lấy tổng số bản ghi
        var totalCount = await query.CountAsync();

        // Phân trang
        var items = await query.Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<T>
        {
            Items = items,
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}