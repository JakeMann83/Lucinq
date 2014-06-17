using System.Collections.Generic;
using Lucinq.Core.Enums;
using Lucinq.Core.Interfaces;
using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Querying
{
    public class CoreQueryBuilder : ICoreQueryBuilder
    {
        private Matches defaultChildrenOccur;

        protected CoreQueryBuilder()
        {
            Queries = new Dictionary<string, IQueryReference>();
            Occur = Matches.Always;
        }

        /// <summary>
        /// Gets the child queries in the builder
        /// </summary>
        public Dictionary<string, IQueryReference> Queries { get; private set; }

        /// <summary>
        /// Gets or sets the occurance value for the query builder
        /// </summary>
        public Matches Occur { get; set; }

        /// <summary>
        /// Gets or sets the default occur value for child queries within the builder
        /// </summary>
        public Matches DefaultChildrenOccur
        {
            get
            {
                return GetDefaultChildrenOccur();
            }
            set { defaultChildrenOccur = value; }
        }

        /// <summary>
        /// Adds a query to the current group
        /// </summary>
        /// <param name="query">The query to add</param>
        /// <param name="occur">The occur value for the query</param>
        /// <param name="key">A key to allow manipulation from the dictionary later on (a default key will be generated if none is specified</param>
        public virtual void Add(IQuery query, Matches occur, string key = null)
        {
            key = GetQueryKey(key);
            IQueryReference<IQuery> queryReference = new LucinqQueryReference { Occur = occur, Query = query };
            Queries.Add(key, queryReference);
        }

        protected string GetQueryKey(string key)
        {
            if (key == null)
            {
                key = "Query_" + Queries.Count;
            }
            return key;
        }


        /// <summary>
        /// Gets the default child occur value
        /// </summary>
        /// <returns></returns>
        protected virtual Matches GetDefaultChildrenOccur()
        {
            if (defaultChildrenOccur == Matches.NotSet)
            {
                defaultChildrenOccur = Matches.Always;
            }
            return defaultChildrenOccur;
        }

    }
}
