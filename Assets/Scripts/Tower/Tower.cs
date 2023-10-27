using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;
    private List<Block> _blocks;

    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();

        _blocks = _towerBuilder.Build();
    }
}
