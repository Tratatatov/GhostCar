using UnityEngine;

public class GameplayController : MonoBehaviour
{
    private PlaybackController _playbackController;
    private SaveManager _saveManager;
    private TimeCounterController _timeCounterController;
    private SceneController _sceneController;

    public void Initialize(PlaybackController playbackController, SaveManager saveManager, TimeCounterController timeCounterController, SceneController sceneController)
    {
        _playbackController = playbackController;
        _saveManager = saveManager;
        _timeCounterController = timeCounterController;
        _sceneController = sceneController;
    }

    private void Start()
    {
        StartRace();
    }

    public void StartRace()
    {
        _saveManager.Load();
        _timeCounterController.ResetTimer();
        _timeCounterController.UpdateBestTime(_saveManager.CurrentData.BestTime);
        _playbackController.StartRecording();
        _timeCounterController.StartTimer();
        _playbackController.StartPlay(_saveManager.CurrentData.SavePoints);
    }

    public void FinishRace()
    {
        _playbackController.StopRecording();
        _timeCounterController.StopTimer();
        //_saveManager.Save(_saveManager.CurrentData);
        _saveManager.SaveBestResult(_timeCounterController.CurrentTime, _playbackController.GetSavePoints());
        _timeCounterController.UpdateBestTime(_saveManager.CurrentData.BestTime);
        Invoke(nameof(RestartRace), 3f);
    }

    public void RestartRace()
    {

        _sceneController.ResetScene();
    }

    private void Update()
    {
        _timeCounterController.UpdateTimer(Time.deltaTime);
    }
}
