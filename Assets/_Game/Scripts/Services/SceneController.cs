using UnityEngine.SceneManagement;

public class SceneController
{
    public void ResetScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

}

