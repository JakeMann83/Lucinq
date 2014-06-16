namespace Lucinq.Core.QueryTypes
{
    public interface IFieldQuery : IQuery
    {
        string Field { get; set; }
    }
}
