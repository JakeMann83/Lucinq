﻿using System.Collections.Generic;
using Lucinq.Core.Enums;
using Lucinq.Core.Interfaces;
using Lucinq.Core.QueryTypes;
using Lucinq.Core.Visitors;

namespace Lucinq.Core.Querying
{
    public abstract class CoreQueryBuilder : ICoreQueryBuilder
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
        /// Gets or sets whether the query is to be case sensitive
        /// </summary>
        public bool CaseSensitive { get; set; }

        /// <summary>
        /// Adds a query to the current group
        /// </summary>
        /// <param name="query">The query to add</param>
        /// <param name="occur">The occur value for the query</param>
        /// <param name="key">A key to allow manipulation from the dictionary later on (a default key will be generated if none is specified</param>
        public virtual void Add<TNative>(TNative query, Matches occur, string key = null)
        {
            SetOccurValue(this, ref occur);
            IQueryReference nativeReference = GetNativeReference(query, occur, key);
            if (nativeReference != null)
            {
                Queries.Add(GetQueryKey(key), nativeReference);
                return;
            }

            IQueryReference<TNative> queryReference = new LucinqQueryReference<TNative> { Occur = occur, Query = query };
            Queries.Add(GetQueryKey(key), queryReference);
        }

        protected abstract IQueryReference GetNativeReference<TNative>(TNative query, Matches occur, string key);

        /// <summary>
        /// Sets up and adds a term query object allowing the search for an explcit term in the field
        /// Note: Wildcards should use the wildcard query type.
        /// </summary>
        /// <param name="adapter">The query adapter</param>
        /// <param name="fieldName">The field name to search within</param>
        /// <param name="fieldValue">The value to match</param>
        /// <param name="occur">Whether it must, must not or should occur in the field</param>
        /// <param name="boost">A boost multiplier (1 is default / normal).</param>
        /// <param name="key">The dictionary key to allow reference beyond the initial scope</param>
        /// <param name="caseSensitive">A boolean denoting whether or not to retain case</param>
        /// <returns>The generated term query</returns>
        public TNative AddFieldValueQuery<TNative>(IQueryAdapter<IFieldValueQuery, TNative> adapter, string fieldName, string fieldValue, Matches occur = Matches.NotSet, float? boost = null, string key = null,
            bool? caseSensitive = null)
        {
            bool actualCaseSensitivity = caseSensitive ?? CaseSensitive;

            SetOccurValue(this, ref occur);

            LucinqFieldValueQuery query = new LucinqFieldValueQuery();
            query.Field = fieldName;
            query.Value = fieldValue;
            query.CaseSensitive = actualCaseSensitivity;
            query.Boost = boost;

            FieldValueQueryVisitor<TNative> visitor = new FieldValueQueryVisitor<TNative>(adapter, query, occur);
            LucinqQueryReference<IQueryBuilderVisitor> reference = new LucinqQueryReference<IQueryBuilderVisitor>();
            reference.Query = visitor;
            reference.Occur = occur;

            Queries.Add(GetQueryKey(key), reference);
            return adapter.GetQuery(query);
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


        protected virtual void SetOccurValue(ICoreQueryBuilder inputQueryBuilder, ref Matches occur)
        {
            if (occur != Matches.NotSet)
            {
                return;
            }

            occur = inputQueryBuilder != null ? inputQueryBuilder.DefaultChildrenOccur : Matches.Always;
        }

    }
}
