using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Scriptable Objects/GameConfig")]
public class GameConfig : ScriptableObject
{
    [SerializeField] private float _recordingTimeStep;

    public float RecordingTimeStep { get => _recordingTimeStep; }
}
