using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlayer
{
    private MonoBehaviour _ghostPlayer;
    private Transform _ghostTransform; //ссылка на перемещаемый объект ("призрак" игрока)
    private float _timeStep;
    private Coroutine _playbackRoutine;

    public GhostPlayer(Transform ghostTransform, MonoBehaviour ghostPlayer, float timeStep)
    {
        _ghostTransform = ghostTransform;
        _timeStep = timeStep;
        _ghostPlayer = ghostPlayer;
    }

    public void StartPlayback(List<SavePoint> savePoints)
    {
        _playbackRoutine = _ghostPlayer.StartCoroutine(PlaybackRoutine(savePoints));
    }

    public void StopPlayback()
    {
        _ghostTransform.gameObject.SetActive(false);
    }

    public void SetGhostVisible(bool value)
    {
        _ghostTransform.gameObject.SetActive(value);
    }

    private IEnumerator PlaybackRoutine(List<SavePoint> savePoints)
    {
        if (savePoints == null || savePoints.Count == 0)
        {
            yield break;
        }

        float startTime = Time.time;
        int currentFrameIndex = 0;

        while (currentFrameIndex < savePoints.Count - 1)
        {
            float elapsedTime = Time.time - startTime;

            // Находим текущий и следующий кадры
            while (currentFrameIndex < savePoints.Count - 1 &&
                   savePoints[currentFrameIndex + 1].Time <= elapsedTime)
            {
                currentFrameIndex++;
            }

            if (currentFrameIndex >= savePoints.Count - 1) break;

            SavePoint frameA = savePoints[currentFrameIndex];
            SavePoint frameB = savePoints[currentFrameIndex + 1];

            // Интерполяция
            float t = Mathf.InverseLerp(frameA.Time, frameB.Time, elapsedTime);
            _ghostTransform.position = Vector3.Lerp(frameA.Position, frameB.Position, t);
            _ghostTransform.rotation = Quaternion.Slerp(frameA.Rotation, frameB.Rotation, t);

            yield return null;
        }

        // Завершаем на последнем кадре
        if (savePoints.Count > 0)
        {
            var lastFrame = savePoints[savePoints.Count - 1];
            _ghostTransform.position = lastFrame.Position;
            _ghostTransform.rotation = lastFrame.Rotation;
        }
    }
}
