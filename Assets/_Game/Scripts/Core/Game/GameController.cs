using UnityEngine;

public sealed class GameController : MonoBehaviour
{
    private GameStateMachine _stateMachine;
    private GameSession _session;

    private void Awake()
    {
        _session = GameSession.LoadOrCreate();
        _stateMachine = new GameStateMachine(_session);

        EventBus.Subscribe<FinalScoreComputed>(e =>
        {
            ScorePersistence.Save(e.Score);
        });
        
        var difficulty = new DifficultyController();
        var score = new ScoreCalculator(difficulty);

        var players = new PlayerRepository();
        var leaderboard = new LeaderboardController();

    }

    private void Start()
    {
        _stateMachine.EnterInitialState();
    }
}
