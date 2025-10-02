using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    private bool _isPressed;

    private Vector3 _direction = Vector3.up;

    public event Action<Vector3> UpButtonHeld;
    public event Action UpButtonReleased;
   
    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
        StartCoroutine(Holding());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
        StopCoroutine(Holding());
        UpButtonReleased?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isPressed = false;
        StopCoroutine(Holding());
        UpButtonReleased?.Invoke();
    }

    private IEnumerator Holding()
    {
        while(_isPressed)
        {
            UpButtonHeld?.Invoke(_direction);

            yield return null;
        }
    }
}