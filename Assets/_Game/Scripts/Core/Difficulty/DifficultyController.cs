public sealed class DifficultyController
{
    private readonly DifficultyState _state = new();

    public DifficultyController()
    {
        DifficultyPersistence.Load(_state);
        EventBus.Subscribe<GameOverTriggered>(_ => OnGameCompleted());
    }

    private void OnGameCompleted()
    {
        _state.Reduce();
        DifficultyPersistence.Save(_state);
    }

    public double GetPreviewTime()
    {
        return _state.CurrentPreviewTime;
    }
}
