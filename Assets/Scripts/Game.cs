using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Table _table;
    // Start is called before the first frame update
    void Start()
    {
        _table.Initialize();
    }
}
