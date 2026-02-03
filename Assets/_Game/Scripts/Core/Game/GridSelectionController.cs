public sealed class GridSelectionController
{
    public CardGridConfig SelectedGrid { get; private set; }

    public GridSelectionController()
    {
        EventBus.Subscribe<GridSelected>(e =>
            SelectedGrid = e.Config);
    }
}
