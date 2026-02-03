public sealed class MismatchTracker
{
    private int _mismatches;

    public MismatchTracker()
    {
        EventBus.Subscribe<CardsMismatched>(_ => OnMismatch());
    }

    private void OnMismatch()
    {
        _mismatches++;

        if (_mismatches >= 3)
        {
            EventBus.Raise(new GameOverTriggered());
        }
    }
}
