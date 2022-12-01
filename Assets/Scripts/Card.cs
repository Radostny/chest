using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Suit
{
    Clubs,
    Diamonds,
    Hearts,
    Spades
}
public enum Rank
{
    Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
    Jack, Queen, King, Ace
}

public class Card : MonoBehaviour
{
    [field: SerializeField]
    public Suit Suit { get; private set; }
    [field: SerializeField]
    public Rank Rank { get; private set; }

    public void AssignSuitAndRank(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

}
