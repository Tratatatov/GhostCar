using UnityEngine;

public class DebugManager : MonoBehaviour
{
    [SerializeField] private GameplayController _gameplayController;

    public void RestartLevel()
    {
        _gameplayController.RestartRace();
    }

    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    private void Update()
    {
        
    }
}
