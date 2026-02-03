using System.Collections.Generic;

public sealed class CardSelectionController
{
    private readonly List<CardModel> _buffer = new(2);

    public CardSelectionController()
    {
        EventBus.Subscribe<CardSelected>(OnCardSelected);
    }

    private void OnCardSelected(CardSelected evt)
    {
        if (evt.Card.IsMatched)
            return;

        if (_buffer.Contains(evt.Card))
            return;

        _buffer.Add(evt.Card);

        if (_buffer.Count == 2)
            ResolvePair();
    }

    private void ResolvePair()
    {
        EventBus.Raise(new ResolvePairRequested(_buffer[0], _buffer[1]));
        _buffer.Clear();
    }
}
