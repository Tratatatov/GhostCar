using System;
using UnityEngine;

[Serializable]
public class SavePoint
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private Quaternion _rotation;
    [SerializeField] private float _time; // время с начала записи

    public Vector3 Position { get => _position; }
    public Quaternion Rotation { get => _rotation; }
    public float Time { get => _time; }

    public SavePoint(Vector3 position, Quaternion rotation, float time)
    {
        _position = position;
        _rotation = rotation;
        _time = time;
    }

}
