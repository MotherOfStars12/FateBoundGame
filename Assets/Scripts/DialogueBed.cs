using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueBed : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mamaPanel;
    public GameObject playerPanel;

    [Header("Mama UI")]
    public TMP_Text mamaNameText;
    public TMP_Text mamaDialogText;
    public Transform mamaFaceParent;

    [Header("Player UI")]
    public TMP_Text playerNameText;
    public TMP_Text playerDialogText;
    public Transform playerFaceParent;

    [Header("Faces")]
    public GameObject playerFaceMale;
    public GameObject playerFaceFemale;
    public GameObject mamaFacePrefab;

    [Header("Mama Scene")]
    public GameObject mamaScenePrefab;
    public Transform mamaSpawnPoint;
    private GameObject activeMamaScene;

    [Header("Lines")]
    [TextArea] public string[] mamaLines;
    [TextArea] public string[] playerLines;
    [TextArea] public string[] mamaExtraLines;

    [Header("Player Names")]
    public string maleName = "Soren";
    public string femaleName = "Aveline";

    [Header("Choices")]
    public ChoiceSelection choiceSelection;

    private int index;
    private enum Phase { Mama, Player, ExtraMama, Finished }
    private Phase phase;

    private GameObject activePlayerFace;
    private GameObject activeMamaFace;

    private const string PREF_KEY = "SelectedCharacterIndex";

    void Start()
    {
        SpawnPlayerFace();

        mamaPanel.SetActive(false);
        playerPanel.SetActive(false);

        StartMamaDialogue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !choiceSelection.panel.activeSelf)
        {
            Next();
        }
    }

    void SpawnPlayerFace()
    {
        int idx = PlayerPrefs.GetInt(PREF_KEY, 0);
        GameObject prefab = (idx == 0) ? playerFaceMale : playerFaceFemale;

        activePlayerFace = Instantiate(prefab, playerFaceParent);
        playerNameText.text = (idx == 0) ? maleName : femaleName;
    }

    void StartMamaDialogue()
    {
        phase = Phase.Mama;
        index = 0;

        mamaPanel.SetActive(true);
        playerPanel.SetActive(false);

        mamaNameText.text = "?";
        mamaDialogText.text = mamaLines[index];
    }

    void StartPlayerDialogue()
    {
        phase = Phase.Player;
        index = 0;

        mamaPanel.SetActive(false);
        playerPanel.SetActive(true);

        playerDialogText.text = playerLines[index];
    }

    void StartMamaExtra()
    {
        phase = Phase.ExtraMama;
        index = 0;

        
        if (activeMamaScene == null)
        {
            activeMamaScene = Instantiate(mamaScenePrefab, mamaSpawnPoint.position, mamaSpawnPoint.rotation);
        }

        
        if (activeMamaFace != null) Destroy(activeMamaFace);
        activeMamaFace = Instantiate(mamaFacePrefab, mamaFaceParent);

        mamaPanel.SetActive(true);
        playerPanel.SetActive(false);

        mamaNameText.text = "Serenya";
        mamaDialogText.text = mamaExtraLines[index];
    }

    public void PlayerChoseFiveMore()
    {
        StartMamaExtra();
    }

    public void PlayerChoseWakeUp()
    {
        SceneManager.LoadScene("Nivel1");
    }

    void Next()
    {
        switch (phase)
        {
            case Phase.Mama:
                index++;
                if (index < mamaLines.Length)
                {
                    mamaDialogText.text = mamaLines[index];
                }
                else
                {
                    StartPlayerDialogue();  
                }
                break;

            case Phase.Player:
                index++;
                if (index < playerLines.Length)
                {
                    playerDialogText.text = playerLines[index];
                }
                else
                {
                    choiceSelection.ShowChoices(); 
                }
                break;

            case Phase.ExtraMama:
                index++;

                
                if (index < mamaExtraLines.Length)
                {
                    mamaDialogText.text = mamaExtraLines[index];
                }

                
                if (index >= 1)
                {
                    SceneManager.LoadScene("Nivel1");
                }
                break;
        }
    }
}

