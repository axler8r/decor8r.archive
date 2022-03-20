namespace DecOR8R.Daemon.Decorators;

public interface IDecorator<TS>
{
    public string Decorate(TS subject);
}
