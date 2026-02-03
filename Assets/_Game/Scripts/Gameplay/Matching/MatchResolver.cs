public readonly struct ResolvePairRequested
{
    public readonly CardModel A;
    public readonly CardModel B;

    public ResolvePairRequested(CardModel a, CardModel b)
    {
        A = a;
        B = b;
    }
}
public sealed class MatchResolver
{
    public MatchResolver()
    {
        EventBus.Subscribe<ResolvePairRequested>(OnResolve);
    }

    private void OnResolve(ResolvePairRequested evt)
    {
        if (evt.A.Id.Value == evt.B.Id.Value)
        {
            evt.A.MarkMatched();
            evt.B.MarkMatched();

            EventBus.Raise(new CardsMatched(evt.A, evt.B));
        }
        else
        {
            EventBus.Raise(new CardsMismatched());
        }
    }
}
