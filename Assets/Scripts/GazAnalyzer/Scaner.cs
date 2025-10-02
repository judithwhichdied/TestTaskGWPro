using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaner : MonoBehaviour
{
    [SerializeField] private PowerButton _powerButton;
    [SerializeField] private float _radius = 30f;

    private bool _enabled = false;

    private DangerZone _targetZone;

    public event Action<float> DistanceUpdated;

    private void OnEnable()
    {
        _powerButton.Pressed += SwitchState;
    }

    private void OnDisable()
    {
        _powerButton.Pressed -= SwitchState;
    }

    private void SwitchState()
    {
        if (_enabled)
        {
            _enabled = false;
            StopCoroutine(Scanning());
        }
        else
        {
            _enabled = true;
            StartCoroutine(Scanning());
        }
    }

    private float Scan()
    {
        List<DangerZone> dangerZones = new List<DangerZone>();

        float currentDistance = 0;
        float pastDistance = 10000;

        foreach (Collider hit in Physics.OverlapSphere(transform.position, _radius))
        {
            if (hit.gameObject.TryGetComponent(out DangerZone dangerZone))
            {
                dangerZones.Add(dangerZone);
            }
        }

        foreach (DangerZone dangerZone in dangerZones)
        {
            currentDistance = Vector3.Distance(transform.position, dangerZone.transform.position);

            if (currentDistance < pastDistance)
                _targetZone = dangerZone;

            pastDistance = currentDistance;
        }

        if (_targetZone != null)
        {
            return Vector3.Distance(transform.position, _targetZone.transform.position);
        }

        return 0;
    }

    private IEnumerator Scanning()
    {
        float distance = 0;

        WaitForSeconds wait = new WaitForSeconds(Time.deltaTime);

        while(_enabled) 
        {
            distance = Scan();

            DistanceUpdated?.Invoke(distance);

            yield return wait;
        }
    }
}