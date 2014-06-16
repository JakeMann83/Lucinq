namespace Lucinq.Core.QueryTypes
{
    public interface ITermQuery : IFieldQuery
    {
        string Value { get; set; }

        bool? CaseSensitive { get; set; }
    }
}
