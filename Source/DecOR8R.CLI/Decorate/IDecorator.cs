namespace DecOR8R.CLI
{
#nullable enable
    interface IDecorator
    {
        string Decorate<O, C>(ISegment segment, O options, C configuration)
                where O : class?
                where C : class?;
    }
#nullable disable
}
