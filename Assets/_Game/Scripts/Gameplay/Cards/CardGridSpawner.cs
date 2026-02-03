using UnityEngine;
using System.Collections.Generic;

public sealed class CardGridSpawner : MonoBehaviour
{
    [SerializeField] private CardSpriteSet spriteSet;
    [SerializeField] private GameObject cardPrefab;

    private GridSelectionController _grid;

    public void Init(GridSelectionController grid)
    {
        _grid = grid;
        EventBus.Subscribe<GameStateChanged>(OnStateChanged);
    }

    private void OnStateChanged(GameStateChanged e)
    {
        if (e.State == GameState.Preview)
            Spawn();
    }

    private void Spawn()
    {
        var config = _grid.SelectedGrid;
        ClearExisting();

        var deck = CardDeckBuilder.BuildDeck(
            config.TotalCells,
            spriteSet
        );

        int index = 0;

        for (int r = 0; r < config.rows; r++)
        {
            for (int c = 0; c < config.columns; c++)
            {
                var id = deck[index++];
                CreateCard(id, r, c, config);
            }
        }
    }

    private void CreateCard(
        CardId id, int r, int c, CardGridConfig config)
    {
        var go = Instantiate(cardPrefab, transform);

        go.transform.localPosition = new Vector3(
            c * config.spacing,
            -r * config.spacing,
            0
        );

        var model = new CardModel(id);
        var view = go.GetComponent<CardView>();

        view.Model = model;
        view.SetSprite(spriteSet.sprites[id.Value]);
    }

    private void ClearExisting()
    {
        foreach (Transform t in transform)
            Destroy(t.gameObject);
    }
}
