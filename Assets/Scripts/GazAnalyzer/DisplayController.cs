using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisplayController : MonoBehaviour
{
    [SerializeField] private PowerButton _powerButton;
    [SerializeField] private RectTransform _display;

    private Vector3 _defaultScale = new Vector3(0.00011f, 9e-05f, 0.00011f);
    private float _scaleDelta = 0.00003f;

    private void Awake()
    {
        _powerButton.Pressed += TurnOn;
        _display.localScale = Vector3.zero;
        _display.gameObject.SetActive(false);    
    }

    private void TurnOn()
    {
        if (_display.gameObject.activeSelf)
        {
            StartCoroutine(Switching(Vector3.zero));
            _display.gameObject.SetActive(false);
        }
        else
        {
            _display.gameObject.SetActive(true);
            StartCoroutine(Switching(_defaultScale));
        }
    }

    private IEnumerator Switching(Vector3 scale)
    {
        WaitForSeconds wait = new WaitForSeconds(0.05f);

        while (_display.localScale != scale)
        {
            _display.localScale = Vector3.MoveTowards(_display.localScale, scale, _scaleDelta);

            yield return wait;
        }
    }
}