using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroJuego_SceneLoader : MonoBehaviour
{
    public string nextSceneName = "MainMenu";
    public float delay = 4f;
    void Start()
    {
        Invoke("LoadNextScene", delay);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
