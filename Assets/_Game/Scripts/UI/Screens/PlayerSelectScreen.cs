using UnityEngine;

public sealed class PlayerSelectScreen : MonoBehaviour
{
    public void SelectPlayer(PlayerProfile player)
    {
        EventBus.Raise(new PlayerSelected(player));
        EventBus.Raise(new PlayerConfirmed());
    }
}

public readonly struct PlayerConfirmed { }
