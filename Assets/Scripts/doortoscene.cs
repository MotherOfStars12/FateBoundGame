using UnityEngine;
using UnityEngine.SceneManagement;


public class doortoscene : MonoBehaviour
{
    public string sceneName = "Nivel2";
    public float interactDistance = 1.5f;

    private Transform player;

    void Start()
    {
        var p = FindFirstObjectByType<player_movement>();
        if (p != null) player = p.transform;
    }

    void OnMouseDown()
    {
        if (player == null) return;

        float dist = Vector2.Distance(transform.position, player.position);

        if (dist <= interactDistance)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Estás muy lejos para usar la puerta");
        }
    }
}


