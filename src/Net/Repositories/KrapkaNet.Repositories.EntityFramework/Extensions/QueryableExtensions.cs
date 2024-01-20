using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace KrapkaNet.Repositories.EntityFramework.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> queryable, int page, int pageSize)
        {
            return queryable.Skip((page - 1) * pageSize).Take(pageSize);
        }
    
        public static IEnumerable<TModel> Map<T, TModel>(this IQueryable<T> queryable, Expression<Func<T, TModel>> selector)
        {
            if (selector.Body is MemberInitExpression mie)
            {
                var bindings = mie.Bindings.ToList();
                foreach (var binding in bindings)
                {
                    if (binding is MemberAssignment ma)
                    {
                        if (ma.Expression is MethodCallExpression mce)
                        {
                            var arguments = mce.Arguments.ToList();
                            foreach (var arg in arguments)
                            {
                                var type = arg.Type;
                            }
                        }
                        var member = ma.Member;
                    } 
                }
            }
            return queryable.Select(selector);
        }
    }
}