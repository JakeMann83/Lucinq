﻿using System;
using System.Diagnostics;
using System.IO;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucinq.Interfaces;

namespace Lucinq.Querying
{
	public class LuceneSearch : ILuceneSearch<LuceneSearchResult>, IDisposable
	{
		#region [ Constructors ]

		public LuceneSearch(string indexPath)
		{
			IndexSearcher = new IndexSearcher(FSDirectory.Open(new DirectoryInfo(indexPath)), true);
		}

		#endregion

		#region [ Properties ]

		public IndexSearcher IndexSearcher { get; private set; }

		#endregion

		#region [ Methods ]

		public virtual LuceneSearchResult Execute(Query query, int noOfResults = Int32.MaxValue - 1, Sort sort = null)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			if (sort == null)
			{
				sort = Sort.RELEVANCE;
			}
			
			TopDocs topDocs = IndexSearcher.Search(query, null, noOfResults, sort);
			stopwatch.Stop();
			LuceneSearchResult searchResult = new LuceneSearchResult(this, topDocs)
				{
					ElapsedTimeMs = stopwatch.ElapsedMilliseconds
				};
			return searchResult;
		}

		public LuceneSearchResult Execute(IQueryBuilder queryBuilder, int noOfResults = Int32.MaxValue - 1)
		{
			return Execute(queryBuilder.Build(), noOfResults, queryBuilder.CurrentSort);
		}

		#endregion

		public void Dispose()
		{
			IndexSearcher.Dispose();
		}
	}
}
