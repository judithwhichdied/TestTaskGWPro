using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    private WaitForSeconds _wait;

    private int _duration = 3;

    private bool _held = false;

    public event Action Pressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        _held = true;

        StartCoroutine(Holding());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _held = false;

        StopCoroutine(Holding());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _held = false;

        StopCoroutine(Holding());
    }

    private IEnumerator Holding()
    {
        _wait = new WaitForSeconds(_duration);

        yield return _wait;

        if (_held)
            Pressed?.Invoke();
    }
}