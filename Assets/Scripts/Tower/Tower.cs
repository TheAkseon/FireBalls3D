using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    [SerializeField] private ParticleSystem _blockDestroyEffect;
    [SerializeField] private Color[] _colors;

    private TowerBuilder _towerBuilder;
    private List<Block> _blocks;

    public UnityAction<int> SizeUpdated;

    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();

        _blocks = _towerBuilder.Build();

        foreach (Block block in _blocks)
        {
            block.GetComponent<MeshRenderer>().material.color = _colors[Random.Range(0, _colors.Length)];
            block.BulletHit += OnBulletHit;
        }

        SizeUpdated?.Invoke(_blocks.Count);
    }

    private void OnBulletHit(Block hitedBlock)
    {
        hitedBlock.BulletHit -= OnBulletHit;

        SpawnDestroyBlockEffect(hitedBlock);

        _blocks.Remove(hitedBlock);

        Destroy(hitedBlock.gameObject);

        foreach (Block block in _blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x, 
                block.transform.position.y - block.transform.localScale.y, block.transform.position.z);
        }

        SizeUpdated?.Invoke(_blocks.Count);
    }

    private void SpawnDestroyBlockEffect(Block hitedBlock)
    {
        ParticleSystemRenderer particleSystemRenderer = Instantiate(_blockDestroyEffect, hitedBlock.transform.position, _blockDestroyEffect.transform.rotation).GetComponent<ParticleSystemRenderer>();
        particleSystemRenderer.material.color = hitedBlock.GetComponent<MeshRenderer>().material.color;
    }
}
