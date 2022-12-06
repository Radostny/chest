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

    void Start()
    {
        _table.Initialize();
    }

    private void Update()
    {
        Debug.DrawRay(_camera.transform.position, Vector3.forward, Color.yellow);
        if (Physics.Raycast(TouchRay, out _hit))
        {
            if (_hit.collider.gameObject.GetComponentInParent<Card>())
            {
                Debug.Log(_hit.collider.gameObject.GetComponentInParent<Card>().Rank);
            }
        }
    }
}
