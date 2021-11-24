namespace DecOR8R.Daemon.Decorators;

public interface IDecorator<S>
{
    public string Decorate(S subject);
}
