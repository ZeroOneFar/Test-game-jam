public readonly struct CardSelected
{
    public readonly CardModel Card;
    public CardSelected(CardModel card) => Card = card;
}

public readonly struct CardsMatched
{
    public readonly CardModel A;
    public readonly CardModel B;

    public CardsMatched(CardModel a, CardModel b)
    {
        A = a;
        B = b;
    }
}

public readonly struct CardsMismatched { }
