using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Transform _startSpawnPoint;
    [SerializeField] private Block _block;
    [SerializeField] private int _towerSize;

    private Vector3 _currentSpawnPoint;

    private void Awake()
    {
        _currentSpawnPoint.y = _startSpawnPoint.localPosition.y + _block.transform.localScale.y / 2f;
    }

    public List<Block> Build()
    {
        List<Block> blocks = new List<Block>();

        for (int i = 0; i < _towerSize; i++)
        {
            Block newBlock = BuildBlock();
            blocks.Add(newBlock);
        }

        return blocks;
    }

    private Block BuildBlock()
    {
        Block block = Instantiate(_block, _currentSpawnPoint, Quaternion.identity, transform);

        _currentSpawnPoint.y += _block.transform.localScale.y;

        return block;
    }
}
