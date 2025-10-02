using UnityEngine;

public class TubeRotator : MonoBehaviour
{
    [SerializeField] private Mover _hookMover;

    [SerializeField] private float _rotationSpeed;

    private void OnEnable()
    {
        _hookMover.Moved += RotateTube;
    }

    private void OnDisable()
    {
        _hookMover.Moved -= RotateTube;
    }

    private void RotateTube(Vector3 direction)
    {
        transform.Rotate(direction.y * _rotationSpeed * Time.deltaTime, direction.x, direction.z);
    }
}