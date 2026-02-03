public sealed class LeaderboardController
{
    private readonly LeaderboardModel _model = new();
    private PlayerProfile _currentPlayer;

    public LeaderboardController()
    {
        _model.Restore(LeaderboardPersistence.Load());

        EventBus.Subscribe<PlayerSelected>(e => _currentPlayer = e.Player);
        EventBus.Subscribe<FinalScoreComputed>(OnFinalScore);
    }

    private void OnFinalScore(FinalScoreComputed evt)
    {
        if (_currentPlayer == null)
            return;

        if (!_model.Qualifies(evt.Score))
            return;

        _model.Add(new ScoreEntry(_currentPlayer.Name, evt.Score));
        LeaderboardPersistence.Save(_model.Top25);
    }
}
