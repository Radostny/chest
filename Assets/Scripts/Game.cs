using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Table _table;
    [SerializeField] Camera _camera;
    private Ray TouchRay => _camera.ScreenPointToRay(Input.mousePosition);
    private RaycastHit _hit;
    private Card _prevCard;

    void Start()
    {
        _table.Initialize();
    }

    private void Update()
    {
        TrackCardTouch();
    }

    private void TrackCardTouch()
    {
        Debug.DrawRay(_camera.transform.position, Vector3.forward, Color.yellow);
        if (Physics.Raycast(TouchRay, out _hit))
        {
            Card currentCard = _hit.collider.gameObject.GetComponentInParent<Card>();
            if (!currentCard && _prevCard)
            {
                _table.DropOff(_prevCard);
            }
            if (currentCard && currentCard != _prevCard)
            {
                _table.PickUp(currentCard);
                if (_prevCard)
                {
                    _table.DropOff(_prevCard);
                }
                _prevCard = currentCard;
            }
        }
        else
        {
            if (_prevCard)
            {
                _table.DropOff(_prevCard);
                _prevCard = null;
            }
        }
    }
}
