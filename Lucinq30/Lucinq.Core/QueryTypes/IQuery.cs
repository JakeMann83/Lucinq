namespace Lucinq.Core.QueryTypes
{
    public interface IQuery
    {
        float? Boost { get; set; }

        TQuery GetNative<TQuery>();
    }
}
