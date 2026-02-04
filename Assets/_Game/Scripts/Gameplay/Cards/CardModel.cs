public sealed class CardModel
{
    public CardId Id { get; }
    public CardView View { get; private set; }
    public bool IsMatched { get; private set; }

    public CardModel(CardId id)
    {
        Id = id;
    }

    public void MarkMatched()
    {
        IsMatched = true;
    }

        public void BindView(CardView view)
    {
        View = view;
    }
}
