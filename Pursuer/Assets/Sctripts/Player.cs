using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(InputReader))]
public class Player : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;
    [SerializeField] private float _strafeSpeed;
    [SerializeField] private float _horizontalTurnSensitivity;
    [SerializeField] private float _verticalTurnSensitivity;
    [SerializeField] private float _verticalMinAngle;
    [SerializeField] private float _verticalMaxAngle;

    private Transform _trasform;
    private CharacterController _characterController;
    private InputReader _inputReader;

    private Transform _cameraTransform;
    private float _cameraAngle;

    private void Awake()
    {
        _trasform = transform;
        _characterController = GetComponent<CharacterController>();
        _inputReader = GetComponent<InputReader>();

        _cameraTransform = _camera.transform;
        _cameraAngle = _cameraTransform.localEulerAngles.x;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 forward = Vector3.ProjectOnPlane(_cameraTransform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(_cameraTransform.right, Vector3.up).normalized;

        _cameraAngle -= _inputReader.GetMouseYAxis() * _verticalTurnSensitivity;
        _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
        _cameraTransform.localEulerAngles = Vector3.right * _cameraAngle;

        _trasform.Rotate(Vector3.up * _horizontalTurnSensitivity * _inputReader.GetMouseXAxis());

        Vector3 playerSpeed = forward * _inputReader.GetVerticalAxis() * _speed + right * _inputReader.GetHorizontalAxis() * _strafeSpeed;
        playerSpeed *= Time.deltaTime;

        if (_characterController.isGrounded)
            _characterController.Move(playerSpeed + Vector3.down);
        else
            _characterController.Move(_characterController.velocity + Physics.gravity * Time.deltaTime);
    }
}