using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    private bool _isPressed;

    private Vector3 _direction = -Vector3.back;

    public event Action<Vector3> BackButtonHeld;

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
        StartCoroutine(Holding());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
        StopCoroutine(Holding());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isPressed = false;
        StopCoroutine(Holding());
    }

    private IEnumerator Holding()
    {
        while (_isPressed)
        {
            BackButtonHeld?.Invoke(_direction);

            yield return null;
        }
    }
}
