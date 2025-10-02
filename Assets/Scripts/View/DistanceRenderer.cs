using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class DistanceRenderer : MonoBehaviour
{
    [SerializeField] private Scaner _scaner;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _scaner.DistanceUpdated += WriteDistance;
    }

    private void OnDisable()
    {
        _scaner.DistanceUpdated -= WriteDistance;
    }

    private void WriteDistance(float distance)
    {
        float roundedDistance = Mathf.Ceil(distance);

        _text.text = $"{roundedDistance.ToString()} m";
    }
}