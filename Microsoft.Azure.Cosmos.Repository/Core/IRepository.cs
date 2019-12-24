using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Cosmos.Core
{

    public interface IRepository
    {
    }
    /// <summary>
    /// Represents the repository with specific type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IRepository where T : class, IConcern
    {
        /// <summary>
        /// Gets item by id from db.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(string id);
        /// <summary>
        /// Adds item into db.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);
        /// <summary>
        /// Updates item in db.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateAsync(T entity);
        /// <summary>
        /// Deletes item from db.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(T entity);
        /// <summary>
        /// Query items from db.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<IList<T>> GetItemsByQuery(string query);
        /// <summary>
        /// Deletes item from db.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsyncById(string id);
    }
}
