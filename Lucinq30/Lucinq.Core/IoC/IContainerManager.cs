namespace Lucinq.Core.IoC
{
    public interface IContainerManager
    {
        T Resolve<T>();

        T Resolve<T>(string name);
    }
}
