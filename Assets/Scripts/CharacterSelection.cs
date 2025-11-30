using UnityEngine;
using UnityEngine.UI;      // Esto se pone para cuando usemos Image y Text 
using UnityEngine.SceneManagement;

public class CharacterSelectionUI : MonoBehaviour
{
    
    public string gameSceneName = "BedScene";
    // 0 = Hombre, 1 = Mujer
    public Sprite[] previewSprites;
    public GameObject[] playerPrefabs;
    public Image previewImage;
    public Text playerLabel;
    private int currentIndex = 0;

    
    private const string PREF_KEY = "SelectedCharacterIndex";

    void Start()
    {
        
        if (PlayerPrefs.HasKey(PREF_KEY))
        {
            currentIndex = PlayerPrefs.GetInt(PREF_KEY);
          
            currentIndex = Mathf.Clamp(currentIndex, 0, previewSprites.Length - 1);
        }
        UpdateUI();
    }

    
    public void Next()
    {
        currentIndex++;
        if (currentIndex >= previewSprites.Length) currentIndex = 0; 
        UpdateUI();
    }

    
    public void Previous()
    {
        currentIndex--;
        if (currentIndex < 0) currentIndex = previewSprites.Length - 1; 
        UpdateUI();
    }

    
    private void UpdateUI()
    {
        if (previewImage != null && previewSprites != null && previewSprites.Length > 0)
        {
            previewImage.sprite = previewSprites[currentIndex];
        }

        if (playerLabel != null)
        {
            string name = (currentIndex == 0) ? "Hombre" : "Mujer";
            playerLabel.text = "Player: " + name;
        }
    }

    
    public void Play()
    {
        
        PlayerPrefs.SetInt(PREF_KEY, currentIndex);
        PlayerPrefs.Save();

        
        if (playerPrefabs == null || playerPrefabs.Length != previewSprites.Length)
        {
            Debug.LogWarning("CharacterSelectionUI: Asegúrate de que playerPrefabs y previewSprites tengan la misma longitud.");
        }

         
        SceneManager.LoadSceneAsync(gameSceneName);
    }

    public void ClearSelection()
    {
        PlayerPrefs.DeleteKey(PREF_KEY);
    }
}

