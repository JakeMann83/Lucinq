using System;
using System.Collections.Generic;
using Lucinq.Core.Enums;

namespace Lucinq.Core.Querying
{
    public abstract partial class AbstractQueryBuilder<TQueryBuilder> : CoreQueryBuilder where TQueryBuilder : class, ICoreQueryBuilder
    {
        protected AbstractQueryBuilder()
        {
            Groups = new List<TQueryBuilder>();
        } 

        /// <summary>
        /// Gets the parent query builder
        /// </summary>
        public TQueryBuilder Parent { get; set; }

        protected abstract TQueryBuilder CreateNewChildGroup(Matches occur = Matches.NotSet,
            Matches childrenOccur = Matches.NotSet);

        #region [ Setup Expressions ]

		/// <summary>
		/// A setup method to aid multiple query setup
		/// </summary>
		/// <param name="queries">Comma seperated lambda actions</param>
		/// <returns>The input querybuilder</returns>
		public virtual TQueryBuilder Setup(params Action<TQueryBuilder>[] queries)
		{
			AddQueries(queries);
			return this as TQueryBuilder;
		}

	    protected void AddQueries(params Action<TQueryBuilder>[] queries)
	    {
            foreach (Action<TQueryBuilder> item in queries)
            {
                item(this as TQueryBuilder);
            }
	    }

		#endregion
    }
}
