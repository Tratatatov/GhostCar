using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GhostRecorder
{
    private Transform _recordingTransform;
    private MonoBehaviour _recorder;
    private float _timeStep;
    [SerializeField] private List<SavePoint> _frames = new();
    private Coroutine _recordingCoroutine;
    private float _startTime;

    public List<SavePoint> Frames { get => _frames; }

    public GhostRecorder(Transform recordingTransform, MonoBehaviour recorder, float timeStep)
    {
        _recordingTransform = recordingTransform;
        _recorder = recorder;
        _timeStep = timeStep;
    }

    public void StartRecording()
    {
        _frames.Clear();
        _startTime = Time.time;
        _recordingCoroutine = _recorder.StartCoroutine(Recording());
    }

    public void StopRecording() => _recorder.StopCoroutine(_recordingCoroutine);

    private IEnumerator Recording()
    {
        while (true)
        {
            float currentTime = Time.time - _startTime;
            _frames.Add(new SavePoint(_recordingTransform.position, _recordingTransform.rotation, currentTime));
            yield return new WaitForSeconds(_timeStep);
        }
    }
}
