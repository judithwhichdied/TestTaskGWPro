using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DownButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    private bool _isPressed;

    private Vector3 _direction = Vector3.down;

    public event Action<Vector3> DownButtonHeld;
    public event Action DownButtonReleased;

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
        StartCoroutine(Holding());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
        StopCoroutine(Holding());
        DownButtonReleased?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isPressed = false;
        StopCoroutine(Holding());
        DownButtonReleased?.Invoke();
    }

    private IEnumerator Holding()
    {
        while (_isPressed)
        {
            DownButtonHeld?.Invoke(_direction);

            yield return null;
        }
    }
}