using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;

namespace CatalogueGalleryApp.Helpers
{
    public static class DapperHelperExtensions
    { /// <summary>
        /// Helper for automatically mapping one to many relationships.
        /// </summary>
        /// <typeparam name="TParent">Type of the parent</typeparam>
        /// <typeparam name="TChild">Type of the child</typeparam>
        /// <typeparam name="TParentKey">Type of the parent's Key field</typeparam>
        /// <param name="connection">IDbConnection</param>
        /// <param name="sql">Sql query</param>
        /// <param name="parentKeySelector">Parent Selector (e.g. parent => parent.Id)</param>
        /// <param name="childSelector">Child Selector (e.g. parent => parent.children)</param>
        /// <param name="param">Sql parameters</param>
        /// <param name="transaction">IDbTransaction</param>
        /// <param name="buffered">Buffered</param>
        /// <param name="splitOn">Split on field (default: Id or ID)</param>
        /// <param name="commandTimeout">Command Timeout</param>
        /// <param name="commandType">Command Type</param>
        /// <returns>List of TParent with TChild objects mapped</returns>
        public static IEnumerable<TParent> QueryParentChild<TParent, TChild, TParentKey>(
            this IDbConnection connection,
            string sql,
            Func<TParent, TParentKey> parentKeySelector,
            Func<TParent, IList<TChild>> childSelector,
            dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id",
            int? commandTimeout = null, CommandType? commandType = null)
        {
            var cache = new Dictionary<TParentKey, TParent>();

            connection.Query<TParent, TChild, TParent>(
                sql,
                (parent, child) =>
                {
                    if (!cache.ContainsKey(parentKeySelector(parent)))
                    {
                        cache.Add(parentKeySelector(parent), parent);
                    }

                    var cachedParent = cache[parentKeySelector(parent)];
                    var children = childSelector(cachedParent);
                    children.Add(child);
                    return cachedParent;
                },
                param as object, transaction, buffered, splitOn, commandTimeout, commandType);

            return cache.Values;
        }
    }
}