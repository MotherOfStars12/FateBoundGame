using UnityEngine;
using Unity.Cinemachine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public Transform spawnPoint;

    private const string PREF_KEY = "SelectedCharacterIndex";

    void Start()
    {
        int index = PlayerPrefs.GetInt(PREF_KEY, 0);
        index = Mathf.Clamp(index, 0, playerPrefabs.Length - 1);

        GameObject player = Instantiate(playerPrefabs[index], spawnPoint.position, Quaternion.identity);
        player.name = playerPrefabs[index].name;

        // Asignar la cámara al jugador
        FollowCamera(player.transform);
    }

    void FollowCamera(Transform player)
    {
        CinemachineCamera cam = FindFirstObjectByType<CinemachineCamera>();

        if (cam != null)
        {
            cam.Follow = player;
            cam.LookAt = null; 
        }
    }
}

