using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadSpawner : MonoBehaviour
{
    public GameObject[] headPrefabs;    // 0 = Hombre, 1 = Mujer 
    public Transform headSpawnPoint;    
    public string nextSceneName = "Nivel1"; 

    private const string PREF_KEY = "SelectedCharacterIndex";
    private GameObject spawnedHead;

    void Start()
    {
        SpawnHeadForSelectedCharacter();
    }

    void SpawnHeadForSelectedCharacter()
    {
        int index = 0;
        if (PlayerPrefs.HasKey(PREF_KEY))
            index = PlayerPrefs.GetInt(PREF_KEY);

        if (headPrefabs == null || headPrefabs.Length == 0)
        {
            Debug.LogError("IntroHeadSpawner: no hay headPrefabs asignados.");
            return;
        }

        index = Mathf.Clamp(index, 0, headPrefabs.Length - 1);

        if (headSpawnPoint == null)
        {
            Debug.LogError("IntroHeadSpawner: headSpawnPoint no está asignado.");
            return;
        }

        spawnedHead = Instantiate(headPrefabs[index], headSpawnPoint.position, headSpawnPoint.rotation, headSpawnPoint);
        spawnedHead.name = headPrefabs[index].name + "_IntroHead";

    }

    
    public void OnIntroFinished()
    {
       
        if (spawnedHead != null)
        {
            var anim = spawnedHead.GetComponent<Animator>();
            if (anim != null) anim.SetBool("isSleeping", false);
        }

       
        SceneManager.LoadScene(nextSceneName);
    }
}
