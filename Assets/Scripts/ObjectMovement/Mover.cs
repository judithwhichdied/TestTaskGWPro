using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private int _speed;

    public event Action<Vector3> Moved;
    public event Action Stopped;

    public void Move(Vector3 direction)
    {
        transform.position += direction * _speed * Time.deltaTime;

        Moved?.Invoke(direction);
    }

    public void Stop()
    {
        Stopped?.Invoke();
    }
}