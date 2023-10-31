using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Vector3 _moveDirection;
    private float _explosionForce = 50f;
    private float _explosionRadius = 50f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _moveDirection = Vector3.forward;
    }

    private void Update()
    {
        Move();
        Destroy(gameObject, 5f);
    }

    private void Move()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Block block))
        {
            block.BulletHit?.Invoke(block);
            Destroy(gameObject);
        }

        if(other.TryGetComponent(out Obstacle obstacle))
        {
            Vector3 explosionPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            _rigidbody.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
            _moveDirection = Vector3.back + Vector3.up;
        }
    }
}