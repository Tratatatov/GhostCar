using System;
using TMPro;
using UnityEngine;

[Serializable]
public class TimeCounterView
{
    [SerializeField] private TextMeshProUGUI _bestTimeText;
    [SerializeField] private TextMeshProUGUI _currentTimeText;

    public void SetCurrentTimeText(float time) => _currentTimeText.text = $"time: {time.ToString("0.00")}";

    public void SetBestTimeText(float time) => _bestTimeText.text = $"best time: {time.ToString("0.00")}";
}
