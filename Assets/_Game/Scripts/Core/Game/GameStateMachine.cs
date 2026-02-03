public sealed class GameStateMachine
{
    public GameState CurrentState { get; private set; }

    private readonly GameSession _session;

    public GameStateMachine(GameSession session)
    {
        _session = session;
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
