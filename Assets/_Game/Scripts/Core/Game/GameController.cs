using UnityEngine;

public sealed class GameController : MonoBehaviour
{
    private GameStateMachine _stateMachine;
    private CardSelectionController _cardSelection;
    private MatchResolver _matchResolver;
    private MismatchTracker _mismatchTracker;
    private GridSelectionController _grid;
    private PlayerRepository _players;

    private void Awake()
    {
        EventBus.Subscribe<FinalScoreComputed>(e =>
        {
            ScorePersistence.Save(e.Score);
        });
        
        var gridSelection = new GridSelectionController();

        var spawner = FindObjectOfType<CardGridSpawner>();
        var visibility = FindObjectOfType<CardVisibilityController>();

        spawner.Init(gridSelection, visibility);

        _stateMachine = new GameStateMachine(
            GameSession.LoadOrCreate());

        // instantiate gameplay controllers
        _cardSelection = new CardSelectionController();
        _matchResolver = new MatchResolver();
        _mismatchTracker = new MismatchTracker();


        var difficulty = new DifficultyController();
        var score = new ScoreCalculator(difficulty);

        var leaderboard = new LeaderboardController();

        _players = new PlayerRepository();
        FindObjectOfType<PlayerSelectScreen>()
            .Init(_players);   
   
    }

    private void Start()
    {
        _stateMachine.EnterInitialState();
    }
}
