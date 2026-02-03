public sealed class GameStateMachine
{
    public GameState CurrentState { get; private set; }

    private readonly GameSession _session;

    public GameStateMachine(GameSession session)
    {
        _session = session;

        EventBus.Subscribe<PreviewFinished>(_ =>
        {
            if(CurrentState == GameState.Preview)
            {
                Transition(GameState.Playing);
            }
        });

        EventBus.Subscribe<GameOverTriggered>(_ =>
        {
            if (CurrentState == GameState.Playing)
            {
                EventBus.Raise(new PlayGameOverSfx());
                Transition(GameState.GameOver);
            }
        });
        EventBus.Subscribe<RequestPlay>(_ =>
        {
            if (CurrentState == GameState.Home)
                Transition(GameState.PlayerSelect);
        });

        EventBus.Subscribe<PlayerConfirmed>(_ =>
        {
            if (CurrentState == GameState.PlayerSelect)
                Transition(GameState.Preview);
        });

        EventBus.Subscribe<GameOverAcknowledged>(_ =>
        {
            if (CurrentState == GameState.GameOver)
                Transition(GameState.Home);
        });

    }

    public void EnterInitialState()
    {
        if (_session.HasActiveRun)
        {
            CurrentState = GameStateRules.ResolveResumeState(_session);
        }
        else
        {
            CurrentState = GameState.Home;
        }

        EventBus.Raise(new GameStateChanged(CurrentState));
    }

    public void Transition(GameState next)
    {
        if (!GameStateRules.IsValid(CurrentState, next))
            return;

        CurrentState = next;
        EventBus.Raise(new GameStateChanged(CurrentState));
    }
}
