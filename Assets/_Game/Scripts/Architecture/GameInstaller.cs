using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] private PlayerCar _objectToRecord;
    [SerializeField] private GhostView _ghostView;
    [SerializeField] private PlaybackController _playbackController;
    [SerializeField] private FinishLine _finishLine;
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private TimeCounterView _timeCounterView;
    [SerializeField] private GameplayController _gameplayController;

    public PlayerCar ObjectToRecord { get => _objectToRecord; }
    public GhostView GhostView { get => _ghostView; }
    public PlaybackController PlaybackController { get => _playbackController; }
    public FinishLine FinishLine { get => _finishLine; }
    public GameConfig GameConfig { get => _gameConfig; }
    public TimeCounterView TimeCounterView { get => _timeCounterView; }
    public GameplayController GameplayController { get=>_gameplayController;  }
}

