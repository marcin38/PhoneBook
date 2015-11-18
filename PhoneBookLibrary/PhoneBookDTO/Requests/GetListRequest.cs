using System;
using System.Linq;
using System.Linq.Expressions;

namespace PhoneBookDTO.Requests
{
    public class GetListRequest<T>
    {
        /// <summary>
        /// Number of rows you want to get
        /// </summary>
        public int NumberOfEntries { get; set; }

        /// <summary>
        /// Criteria for filtering
        /// </summary>
        public Expression<Func<T, bool>> Filter { get; set; }

        /// <summary>
        /// Criteria for ordering
        /// </summary>
        public Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy { get; set; }

        /// <summary>
        /// Properties that are lazy loaded
        /// </summary>
        public string includeProperties { get; set; }
    }
}
