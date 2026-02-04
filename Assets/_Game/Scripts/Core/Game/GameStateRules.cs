public static class GameStateRules
{
    public static bool IsValid(GameState from, GameState to)
    {
        return (from, to) switch
        {
            (GameState.Home, GameState.PlayerSelect) => true,
            (GameState.PlayerSelect, GameState.Preview) => true,
            (GameState.Preview, GameState.Playing) => true,
            (GameState.Playing, GameState.GameOver) => true,
            (GameState.GameOver, GameState.Home) => true,
            _ => false
        };
    }

    public static GameState ResolveResumeState(GameSession session)
    {
        var elapsed = TimeProvider.UtcNow() - session.LastPausedUtc;

        if (elapsed.TotalMinutes >= 2)
            return GameState.Preview;

        return GameState.Playing;
    }
}
public readonly struct GameStateChanged
{
    public readonly GameState State;
    public GameStateChanged(GameState state) => State = state;
}