using TMPro;
using UnityEngine;

public class TowerSizeView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _towerSize;
    [SerializeField] private Tower _tower;

    private void OnEnable()
    {
        _tower.SizeUpdated += OnSizeUpdated;
    }

    private void OnDisable()
    {
        _tower.SizeUpdated -= OnSizeUpdated;
    }

    private void OnSizeUpdated(int countBlocks)
    {
        _towerSize.text = countBlocks.ToString();
    }
}
