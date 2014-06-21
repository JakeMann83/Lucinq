using System;
using System.Collections.Generic;
using Lucinq.Core.Enums;
using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Querying
{
    public abstract partial class AbstractQueryBuilder<TQueryBuilder>
    {
        /// <summary>
        /// Gets the child groups in the builder
        /// </summary>
        public List<TQueryBuilder> Groups { get; private set; }

        /// <summary>
        /// Creates a simple group that MUST occur, each item of which MUST occur by default
        /// </summary>
        /// <param name="queries">The lamdba expressions showing queries</param>
        /// <returns>The original query builder</returns>
        public virtual TQueryBuilder And(params Action<TQueryBuilder>[] queries)
        {
            return And(Matches.Always, queries);
        }

        /// <summary>
        /// Creates a simple group allowing the specification of whether it should occur, each item of which MUST occur by default
        /// </summary>
        /// <param name="occur">Whether the group must / should occur</param>
        /// <param name="queries">The lamdba expressions showing queries</param>
        public virtual TQueryBuilder And(Matches occur, params Action<TQueryBuilder>[] queries)
        {
            CreateAndGroup(occur, queries);
            return this as TQueryBuilder;
        }

        /// <summary>
        /// Sets up term queries for each of the values specified
        /// (usually or / and / not in depending on the occur specified)
        /// </summary>
        /// <param name="fieldName">The field name to search within</param>
        /// <param name="fieldValues">The values to match</param>
        /// <param name="occur">Whether it must, must not or should occur in the field</param>
        /// <param name="boost">A boost multiplier (1 is default / normal).</param>
        /// <param name="caseSensitive">A boolean denoting whether or not to retain case</param>
        /// <returns>The input query builder</returns>
        public virtual TQueryBuilder AddFieldValuesQueries<TNative>(IQueryAdapter<IFieldValueQuery, TNative> adapter, string fieldName, string[] fieldValues, Matches occur = Matches.NotSet, float? boost = null, bool? caseSensitive = null)
        {
            var group = Group();
            foreach (var fieldValue in fieldValues)
            {
                group.AddFieldValueQuery(adapter, fieldName, fieldValue, occur, boost, caseSensitive: caseSensitive);
            }

            return this as TQueryBuilder;
        }

                /// <summary>
        /// Creates a simple group that MUST occur, each item of which SHOULD occur by default
        /// </summary>
        /// <param name="queries">The lamdba expressions showing queries</param>
        public virtual TQueryBuilder Or(params Action<TQueryBuilder>[] queries)
        {
            return Or(Matches.Always, queries);
        }

        /// <summary>
        /// Creates a simple group allowing the specification of whether it should occur, each item of which SHOULD occur by default
        /// </summary>
        /// <param name="occur">Whether the group must / should occur</param>
        /// <param name="queries">The lamdba expressions showing queries</param>
        public virtual TQueryBuilder Or(Matches occur, params Action<TQueryBuilder>[] queries)
        {
            CreateOrGroup(occur, queries);
            return this as TQueryBuilder;
        }

        /// <summary>
        /// Creates a simple group allowing the specification of whether it should occur, and specification of each items occurance.
        /// </summary>
        /// <param name="occur">Whether the group must / should occur</param>
        /// <param name="childrenOccur">Whether the child query should occur by default</param>
        /// <param name="queries">The lamdba expressions showing queries</param>
        public virtual TQueryBuilder Group(Matches occur = Matches.NotSet, Matches childrenOccur = Matches.NotSet, params Action<TQueryBuilder>[] queries)
        {
            if (occur == Matches.NotSet)
            {
                occur = Matches.Always;
            }
            var groupedBooleanQuery = AddChildGroup(occur, childrenOccur, queries);
            if (groupedBooleanQuery == null)
            {
                throw new Exception("An error occurred creating the inner query");
            }
            return groupedBooleanQuery;
        }

        protected virtual TQueryBuilder AddChildGroup(Matches occur = Matches.NotSet, Matches childrenOccur = Matches.NotSet, params Action<TQueryBuilder>[] queries)
        {
            if (occur == Matches.NotSet)
            {
                occur = Matches.Always;
            }

            if (childrenOccur == Matches.NotSet)
            {
                childrenOccur = Matches.Always;
            }

            TQueryBuilder queryBuilder = CreateNewChildGroup(occur, childrenOccur);
            foreach (var item in queries)
            {
                item(queryBuilder);
            }
            Groups.Add(queryBuilder);
            return queryBuilder;
        }

        #region [ Creation ]

        /// <summary>
        /// Creates a new instance of an and group.
        /// </summary>
        /// <returns>The new instance</returns>
        public virtual TQueryBuilder CreateAndGroup(params Action<TQueryBuilder>[] queries)
        {
            return CreateAndGroup(Matches.Always, queries);
        }

        /// <summary>
        /// Gets a new instance of an and group
        /// </summary>
        /// <param name="occur">Whether the group should occur</param>
        /// <param name="queries">The queries</param>
        /// <returns></returns>
        public virtual TQueryBuilder CreateAndGroup(Matches occur, params Action<TQueryBuilder>[] queries)
        {
            return Group(occur, Matches.Always, queries);
        }

        /// <summary>
        /// Creates a new instance of an or group that MUST occur
        /// </summary>
        /// <param name="queries"></param>
        /// <returns></returns>
        public virtual TQueryBuilder CreateOrGroup(params Action<TQueryBuilder>[] queries)
        {
            return CreateOrGroup(Matches.Always, queries);
        }

        public virtual TQueryBuilder CreateOrGroup(Matches occur, params Action<TQueryBuilder>[] queries)
        {
            return Group(occur, Matches.Sometimes, queries);
        }

        #endregion
    }
}
