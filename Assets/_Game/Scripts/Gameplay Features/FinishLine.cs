using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private GameplayController _gameplayController;

    public void Initialize(GameplayController gameplayController)
    {
        _gameplayController = gameplayController;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerCar>() != null)
        {
            _gameplayController.FinishRace();
        }
    }
}
