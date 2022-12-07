using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private Card _cardPrefab;
    [SerializeField] private List<Card> _cards;
    [SerializeField] private Hand _hand;
    [SerializeField] private Hand _player2;

    
    public void Initialize()
    {
        _cards = new List<Card>();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 2; j <=14; j++)
            {
                Card card = Instantiate(_cardPrefab);
                card.transform.SetParent(transform);
                card.AssignSuitAndRank((Suit)i, (Rank)j);
                _cards.Add(card);
            }
        }
        _cards = Shuffle(_cards);
        DealTo(_hand, 4);
        DealTo(_player2, 4, false);
    }

    public void DealTo(Hand hand, int cardsAmount = 1, bool faceUp = true)  // refactor Hand as an IHand interface, so it could be someone else hand
    {
        for (int i = 0; i < cardsAmount; i++)
        {
            var randomCard = GetRandomCardFrom(_cards, faceUp);
            hand.Add(randomCard);
        }
    }

    public List<Card> Shuffle(List<Card> cards)
    {
        List<Card> shuffled = new();
        for (int i = cards.Count; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i);
            shuffled.Add(cards[randomIndex]);
            cards.RemoveAt(randomIndex);
        }
        return shuffled;
    }

    public Card GetRandomCardFrom(List<Card> cards, bool faceUp = true)
    {
        int randomIndex = Random.Range(0, cards.Count);
        var card = _cards[randomIndex];
        _cards.RemoveAt(randomIndex);
        Draw(card);
        if (faceUp)
        {
            FaceUp(card);
        }
        //   Pick(card);
        return card;
    }


    private void Draw(Card card)
    {
        string rankFormatted = string.Format("{0:d2}", (int)card.Rank);
        string path = "Textures/PlayingCards/" + card.Suit.ToString() + rankFormatted;
        Debug.Log(path);
        Renderer renderer = card.gameObject.GetComponentInChildren<Renderer>();
        Texture texture = Resources.Load<Texture>(path);
        if (renderer && texture)
        {
            renderer.material.mainTexture = texture;
        }
        else
            Debug.Log("Can't get Renderer or Texture");
    }
    private void FaceUp(Card card)
    {
        card.isFaceup = true;
        card.transform.Find("BackCover").gameObject.SetActive(false);
    }

    public void PickUp(Card card)
    {
        card.transform.Rotate(transform.forward, -15f);
        card.transform.position += new Vector3(0, 0, -0.1f);
    }
    public void DropOff(Card card)
    {
        card.transform.Rotate(transform.forward, 15f);
        card.transform.position -= new Vector3(0, 0, -0.1f);
    }
}
