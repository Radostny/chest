using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOnHovering : MonoBehaviour
{
    private void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter");
        Card zoomedCard = gameObject.GetComponentInParent<Card>();
        Debug.Log("<" + zoomedCard.Suit.ToString() + " " + zoomedCard.Rank.ToString() + ">");
        
    }


}
