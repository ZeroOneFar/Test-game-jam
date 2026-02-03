using UnityEngine;

[CreateAssetMenu(
    fileName = "CardGridConfig",
    menuName = "Game/Card Grid Config"
)]
public sealed class CardGridConfig : ScriptableObject
{
    public int rows;
    public int columns;
    public float spacing = 1.2f;

    public int TotalCells => rows * columns;
}
