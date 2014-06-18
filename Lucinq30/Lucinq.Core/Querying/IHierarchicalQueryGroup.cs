using System.Collections.Generic;

namespace Lucinq.Core.Querying
{
	public interface IHierarchicalQueryGroup<TGroup> where TGroup : IHierarchicalQueryGroup<TGroup>
	{
		#region [ Properties ]

		/// <summary>
		/// Gets the parent query builder
		/// </summary>
		TGroup Parent { get; }

		/// <summary>
		/// Gets the child groups in the builder
		/// </summary>
		List<TGroup> Groups { get; }

		#endregion
	}
}
