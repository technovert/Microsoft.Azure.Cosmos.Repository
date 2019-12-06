using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Cosmos.Core
{
    /// <summary>
    /// Represents the repository without specific type.
    /// </summary>
    public interface ICosmosCommonRepository
    {
        /// <summary>
        /// Gets item by id from db.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync<T>(string id) where T : class, IConcern;
        /// <summary>
        /// Adds item into db.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync<T>(T entity) where T : class, IConcern;
        /// <summary>
        /// Updates item in db.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateAsync<T>(T entity) where T : class, IConcern;
        /// <summary>
        /// Deletes item from db.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync<T>(T entity) where T : class, IConcern;

        /// <summary>
        /// Query items from db.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<IList<T>> GetItemsByQuery<T>(string query) where T : class, IConcern;
    }
}
