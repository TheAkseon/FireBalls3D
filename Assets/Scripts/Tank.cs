using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _delayBeetwenShoots;

    private float _timeAfterShoot;

    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if(_timeAfterShoot >= _delayBeetwenShoots)
            {
                Shoot();
                _timeAfterShoot = 0;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
    }
}
