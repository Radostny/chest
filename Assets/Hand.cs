using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private Vector3 _size;
    private Renderer _renderer;
    private MeshCollider _meshColider;
    private List<Card> _cards = new();
    // Start is called before the first frame update
    void Awake()
    {
        _renderer = GetComponentInChildren<Renderer>();
        _meshColider = GetComponentInChildren<MeshCollider>();

        _size = _renderer.bounds.size;
        Debug.Log("width of the Hand is " + _size.x);
        
    }
    
    public void Add(Card card)
    {
        _cards.Add(card);
        RearrangeHand();
    }
    private void RearrangeHand()
    {
        for (int i = 0; i < _cards.Count; i++)
        {
            _cards[i].transform.SetParent(transform);
            _cards[i].transform.localPosition = new Vector3(-_size.x / 2 + i * 0.5f, 0, i * -0.1f);
        }
        
        if (_cards.Count == 1)
        {
            _cards[0].transform.SetParent(transform);
            _cards[0].transform.position = transform.position;
            //_cards[0].transform.position = new Vector3(_size.x / 2, transform.position.y, transform.position.z);
        }
    }

}
