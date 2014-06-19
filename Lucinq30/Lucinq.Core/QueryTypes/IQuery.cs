using Lucinq.Core.Querying;

namespace Lucinq.Core.QueryTypes
{
    public interface IQuery
    {
        float? Boost { get; set; }

        TNative GetNative<TNative>(IQueryAdapter<IFieldValueQuery, TNative> adapter);
    }
}
