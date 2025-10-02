using UnityEngine;

public class CableViewer : MonoBehaviour
{
    [SerializeField] private Transform _startPoint; 
    [SerializeField] private Transform _endPoint;   
    [SerializeField] private LineRenderer _lineRenderer;

    private int _points = 6;

    private void Update()
    {
        UpdateCableVisual();
    }

    private void UpdateCableVisual()
    {
        Vector3[] cablePositions = new Vector3[_points];

        float multiplier = 0.3f;

        for (int i = 0; i < _points; i++)
        {
            float t = i / (float)(_points - 1);
           
            Vector3 basePosition = Vector3.Lerp(_startPoint.position, _endPoint.position, t);
          
            float sag = Mathf.Sin(t * Mathf.PI) * multiplier;
            cablePositions[i] = basePosition + Vector3.down * sag;
        }

        _lineRenderer.positionCount = _points;
        _lineRenderer.SetPositions(cablePositions);
    }
}