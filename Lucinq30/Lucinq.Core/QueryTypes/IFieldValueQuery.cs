namespace Lucinq.Core.QueryTypes
{
    public interface IFieldValueQuery : IFieldQuery
    {
        string Value { get; set; }

        bool? CaseSensitive { get; set; }
    }
}
