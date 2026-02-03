using System.Collections.Generic;

public static class CardDeckBuilder
{
    public static List<CardId> BuildDeck(
        int totalCells,
        CardSpriteSet spriteSet
    )
    {
        if (totalCells <= 0)
            throw new System.ArgumentException("Total cells must be > 0");

        if (totalCells % 2 != 0)
            throw new System.Exception(
                "Grid must have an even number of cells"
            );

        int pairCount = totalCells / 2;

        if (spriteSet == null || spriteSet.sprites == null)
            throw new System.Exception("Sprite set is null");

        if (spriteSet.sprites.Count < pairCount)
            throw new System.Exception(
                $"Not enough sprites. Needed {pairCount}, " +
                $"but got {spriteSet.sprites.Count}"
            );

        // Build list of sprite indices
        var spriteIndices = new List<int>();
        for (int i = 0; i < spriteSet.sprites.Count; i++)
            spriteIndices.Add(i);

        Shuffle(spriteIndices);

        // Build paired deck
        var deck = new List<CardId>(totalCells);

        for (int i = 0; i < pairCount; i++)
        {
            var id = new CardId(spriteIndices[i]);
            deck.Add(id);
            deck.Add(id);
        }

        Shuffle(deck);
        return deck;
    }

    private static void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }
}
