﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Lucene.Net.Documents;
using Lucinq.Interfaces;

namespace Lucinq.Querying
{
    using System;

    public abstract class ItemSearchResult<T> : IItemResult<T>
	{
		#region [ Constructors ]

	    protected ItemSearchResult(ILuceneSearchResult luceneSearchResult)
		{
		    LuceneSearchResult = luceneSearchResult;
		} 

		#endregion

		#region [ Properties ]

	    public int TotalHits
	    {
	        get { return LuceneSearchResult.TotalHits; }
	    }

	    public long ElapsedTimeMs { get; set; }


		public List<T> Items { get; private set; }

        protected ILuceneSearchResult LuceneSearchResult { get; private set; } 

		#endregion

        #region [ Enumerable Methods ]

	    public IEnumerator<T> GetEnumerator()
        {
	        if (Items == null)
	        {
	            Items = GetTopItems().Items;
	        }
            return Items.GetEnumerator();
        }

	    IEnumerator IEnumerable.GetEnumerator()
	    {
	        return GetEnumerator();
        }

        #endregion

        #region [ Methods ]

        public virtual IItemResult<T> GetTopItems()
	    {
	        var topItems = LuceneSearchResult.GetTopItems();
            ElapsedTimeMs = LuceneSearchResult.ElapsedTimeMs;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
	        var results = GetResults(topItems);
            return new ItemResult<T>(results, LuceneSearchResult.TotalHits) { ElapsedTimeMs = stopwatch.ElapsedMilliseconds };

	    }

        private List<T> GetResults(IEnumerable<Document> items)
	    {
	        return items == null ? null : items.Select(GetItem).ToList();
	    }

        /// <summary>
        /// Gets a range of items.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
	    public virtual IItemResult<T> GetRange(int start, int end)
	    {
            var pagedItems = LuceneSearchResult.GetRange(start, end);
            ElapsedTimeMs = LuceneSearchResult.ElapsedTimeMs;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var results = GetResults(pagedItems);
            return new ItemResult<T>(results, LuceneSearchResult.TotalHits) { ElapsedTimeMs = stopwatch.ElapsedMilliseconds };
	    }

        [Obsolete("GetPagedItems is being deprecated, use GetRange instead")]
        public virtual IItemResult<T> GetPagedItems(int start, int end)
        {
            return GetRange(start, end);
        }

	    public abstract T GetItem(Document document);

        #endregion
    }
}
