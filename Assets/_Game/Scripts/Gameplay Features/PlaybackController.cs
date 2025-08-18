using System.Collections.Generic;
using UnityEngine;

public class PlaybackController : MonoBehaviour
{
    private GhostPlayer _ghostPlayer;
    private GhostRecorder _ghostRecorder;

    public void Initialize(GhostPlayer ghostPlayer, GhostRecorder ghostRecorder)
    {
        _ghostPlayer = ghostPlayer;
        _ghostRecorder = ghostRecorder;
        _ghostPlayer.SetGhostVisible(false);
    }

    public List<SavePoint> GetSavePoints()
    {
        return _ghostRecorder.Frames;
    }

    public void StartRecording()
    {
        _ghostRecorder.StartRecording();
    }

    public void StopRecording()
    {
        _ghostRecorder.StopRecording();
    }

    public void StartPlay(List<SavePoint> savePoints)
    {
        if (savePoints.Count==0) return;
        _ghostPlayer.SetGhostVisible(true);
        _ghostPlayer.StartPlayback(savePoints);
    }

    public void StopPlay()
    {
        _ghostPlayer.SetGhostVisible(false);
        _ghostPlayer.StopPlayback();
    }

}

