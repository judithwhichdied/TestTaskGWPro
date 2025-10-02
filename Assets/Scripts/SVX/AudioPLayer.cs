using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPLayer : MonoBehaviour
{
    [SerializeField] private Mover _hookMover;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _hookMover.Moved += PlayClip;
        _hookMover.Stopped += () => _audioSource.Stop();
    }

    private void OnDisable()
    {
        _hookMover.Moved -= PlayClip;
        _hookMover.Stopped -= () => _audioSource.Stop();
    }

    private void PlayClip(Vector3 direction)
    {      
        if (_audioSource.isPlaying == false) 
        {
            _audioSource.Play();
        }
    }  
}