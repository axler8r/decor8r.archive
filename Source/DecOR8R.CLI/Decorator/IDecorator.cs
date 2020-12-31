namespace DecOR8R.CLI
{
#nullable enable
    interface IDecorator
    {
        string Decorate(ISegment segment);
        string Decorate(params ISegment[] segments);
        string Decorate<C>(C configuration, ISegment segment) where C : class?;
        string Decorate<C>(C configuration, params ISegment[] segments) where C : class?;
    }
#nullable disable
}
