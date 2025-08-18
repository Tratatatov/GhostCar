public class TimeCounterController
{
    private float _currentTime;
    private TimeCounterView _timeCounterView;
    private bool _isCounting;

    public float CurrentTime { get => _currentTime; }

    public TimeCounterController(TimeCounterView timeCounterView)
    {
        _timeCounterView = timeCounterView;
    }

    public void StartTimer() =>_isCounting = true;

    public void StopTimer() => _isCounting = false;

    public void UpdateTimer(float value)
    {
        if (_isCounting == false) return;
        _currentTime += value;
        _timeCounterView.SetCurrentTimeText(_currentTime);
    }

    public void ResetTimer()
    {
        _currentTime = 0;
        _timeCounterView.SetCurrentTimeText(_currentTime);
    }

    public void UpdateBestTime(float value)
    {

        _timeCounterView.SetBestTimeText(value);
    }
}

