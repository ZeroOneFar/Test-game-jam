using UnityEngine;

public sealed class GameController : MonoBehaviour
{
    private GameStateMachine _stateMachine;
    private GameSession _session;

    private void Awake()
    {
        _session = GameSession.LoadOrCreate();
        _stateMachine = new GameStateMachine(_session);
    }

    private void Start()
    {
        _stateMachine.EnterInitialState();
    }
}
