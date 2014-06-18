using Lucinq.Core.Querying;

namespace Lucinq.Core.QueryTypes
{
    public class LucinqTermQuery : ITermQuery
    {
        public float? Boost { get; set; }

        public string Field { get; set; }

        public string Value { get; set; }

        public bool? CaseSensitive { get; set; }

        public TNative GetNative<TNative>(IQueryAdapter<ITermQuery, TNative> adapter)
        {
            return adapter.GetQuery(this);
        }
    }
}
