public sealed class CardModel
{
    public CardId Id { get; }
    public bool IsMatched { get; private set; }

    public CardModel(CardId id)
    {
        Id = id;
    }

    public void MarkMatched()
    {
        IsMatched = true;
    }
}
