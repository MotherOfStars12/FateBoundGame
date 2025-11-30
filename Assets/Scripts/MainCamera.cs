using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCamera : MonoBehaviour
{
    public string nextSceneName = "Nivel1";

    public void LoadNextScene()
    {
        SceneManager.LoadSceneAsync(nextSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
