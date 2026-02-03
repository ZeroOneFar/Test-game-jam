using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(
    fileName = "CardSpriteSet",
    menuName = "Game/Card Sprite Set"
)]
public sealed class CardSpriteSet : ScriptableObject
{
    public List<Sprite> sprites;
}
