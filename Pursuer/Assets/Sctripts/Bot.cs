using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bot : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private BotRaycast _botRaycast;
    [SerializeField] private float _speed;
    [SerializeField] private float _minDistance;
    [SerializeField] private float _stepUpForce;
    [SerializeField] private float _gravityForce;

    private Transform _playerTransform;

    private Transform _transform;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;

        _playerTransform = _player.transform;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if ((_playerTransform.position - _transform.position).sqrMagnitude >= _minDistance)
        {
            Vector3 playerPosition = _playerTransform.position;
            playerPosition.y = _transform.position.y;
            _transform.LookAt(playerPosition);

            Vector3 direction = (_playerTransform.position - _transform.position).normalized;
            direction *= _speed;
            _rigidbody.linearVelocity = direction;

            if (_botRaycast.IsRise())
            {
                _rigidbody.AddForce(Vector3.up * _stepUpForce);
            }
            else
            {
                _rigidbody.AddForce(Physics.gravity * _gravityForce);
            }
        }
        else
        {
            _rigidbody.linearVelocity = Vector3.zero;
        }
    }
}