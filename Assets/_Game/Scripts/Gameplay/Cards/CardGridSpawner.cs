using UnityEngine;

public sealed class CardGridSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnParent;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private CardSpriteSet spriteSet;

    private GridSelectionController _grid;
    private CardVisibilityController _visibility;

    public void Init(
        GridSelectionController grid,
        CardVisibilityController visibility
    )
    {
        _grid = grid;
        _visibility = visibility;

        EventBus.Subscribe<GameStateChanged>(OnStateChanged);
    }

    private void OnStateChanged(GameStateChanged e)
    {
        if (e.State == GameState.Preview)
            PreviewSpawn();
    }

    private void PreviewSpawn()
    {
        if (_grid?.SelectedGrid == null)
        {
            Debug.LogError("[CardGridSpawner] No grid selected");
            return;
        }

        if (_visibility == null)
        {
            Debug.LogError("[CardGridSpawner] CardVisibilityController not assigned");
            return;
        }

        ClearExisting();

        var config = _grid.SelectedGrid;
        var deck = CardDeckBuilder.BuildDeck(
            config.TotalCells,
            spriteSet
        );

        float spacing = config.spacing;
        int rows = config.rows;
        int cols = config.columns;

        float width  = (cols - 1) * spacing;
        float height = (rows - 1) * spacing;
        Vector2 offset = new Vector2(-width / 2f, height / 2f);

        int index = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                var go = Instantiate(cardPrefab, spawnParent);

                float x = c * spacing;
                float y = -r * spacing;
                go.transform.localPosition =
                    new Vector3(x, y, 0) + (Vector3)offset;

                var model = new CardModel(deck[index++]);
                var view = go.GetComponent<CardView>();
                view.Init(model, spriteSet.sprites[model.Id.Value]);

                // THIS IS THE KEY LINE
                _visibility.Register(view);
            }
        }
        EventBus.Raise( new CardSpawnFinishedFromPreviw());
    }

    private void ClearExisting()
    {
        _visibility.Clear();

        for (int i = spawnParent.childCount - 1; i >= 0; i--)
            Destroy(spawnParent.GetChild(i).gameObject);
    }
}

public readonly struct CardSpawnFinishedFromPreviw
{
    
} 
