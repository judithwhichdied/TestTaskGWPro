using UnityEngine;

public class RemoteController : MonoBehaviour
{
    [SerializeField] private UpButton _upButton;
    [SerializeField] private DownButton _downButton;
    [SerializeField] private RightButton _rightButton;
    [SerializeField] private LeftButton _leftButton;
    [SerializeField] private ForwardButton _forwardButton;
    [SerializeField] private BackButton _backButton;

    [SerializeField] private Mover _balk;
    [SerializeField] private Mover _crane;
    [SerializeField] private Mover _hook;

    private void OnEnable()
    {
        _upButton.UpButtonHeld += _hook.Move;
        _downButton.DownButtonHeld += _hook.Move;
        _rightButton.RightButtonHeld += _crane.Move;
        _leftButton.LeftButtonHeld += _crane.Move;
        _forwardButton.ForwardButtonHeld += _balk.Move;
        _backButton.BackButtonHeld += _balk.Move;
        _upButton.UpButtonReleased += _hook.Stop;
        _downButton.DownButtonReleased += _hook.Stop;   
    }

    private void OnDisable()
    {
        _upButton.UpButtonHeld -= _hook.Move;
        _downButton.DownButtonHeld -= _hook.Move;
        _rightButton.RightButtonHeld -= _crane.Move;
        _leftButton.LeftButtonHeld -= _crane.Move;
        _forwardButton.ForwardButtonHeld -= _balk.Move;
        _backButton.BackButtonHeld -= _balk.Move;
        _upButton.UpButtonReleased -= _hook.Stop;
        _downButton.DownButtonReleased -= _hook.Stop;
    }
}