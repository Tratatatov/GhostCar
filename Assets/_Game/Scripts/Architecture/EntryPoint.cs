using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameInstaller _gameInstaller;

    private GhostPlayer _player;
    private GhostRecorder _recorder;
    private PlaybackController _playbackController;
    private FinishLine _finishLine;
    private IInput _input;
    private SceneController _sceneContoller;
    private TimeCounterController _timeCounterController;
    private SaveManager _saveManager;
    private GameplayController _gameplayController;

    private void Awake()
    {
        InitilizeAllServies();
    }

    public void InitilizeAllServies()
    {
        _player = new GhostPlayer(_gameInstaller.GhostView.transform, this, _gameInstaller.GameConfig.RecordingTimeStep);

        _recorder = new GhostRecorder(_gameInstaller.ObjectToRecord.transform, this, _gameInstaller.GameConfig.RecordingTimeStep);

        _playbackController = _gameInstaller.PlaybackController;
        _playbackController.Initialize(_player, _recorder);

        _input = new DesktopInput();

        _sceneContoller = new SceneController();

        _timeCounterController = new TimeCounterController(_gameInstaller.TimeCounterView);

        _saveManager = new SaveManager();

        _gameplayController = _gameInstaller.GameplayController;
        _gameplayController.Initialize(_playbackController, _saveManager, _timeCounterController, _sceneContoller);

        _finishLine = _gameInstaller.FinishLine;
        _finishLine.Initialize(_gameplayController);
        Debug.Log("All services was initialized");

    }
}

