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

        foreach (Block block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }
    }

    private void OnBulletHit(Block hitedBlock)
    {
        hitedBlock.BulletHit -= OnBulletHit;

        _blocks.Remove(hitedBlock);

        Destroy(hitedBlock.gameObject);

        foreach (Block block in _blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x, 
                block.transform.position.y - block.transform.localScale.y, block.transform.position.z);
        }
    }
}
