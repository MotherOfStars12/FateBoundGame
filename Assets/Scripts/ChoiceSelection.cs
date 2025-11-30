using UnityEngine;

public class ChoiceSelection : MonoBehaviour
{
    public GameObject panel;
    public GameObject selection_5min;
    public GameObject selection_despertar;

    public DialogueBed dialogueBed;

    void Start()
    {
        panel.SetActive(false);
        selection_5min.SetActive(false);
        selection_despertar.SetActive(false);
    }

    public void ShowChoices()
    {
        panel.SetActive(true);
    }

    public void Hover5()
    {
        selection_5min.SetActive(true);
        selection_despertar.SetActive(false);
    }

    public void HoverWake()
    {
        selection_5min.SetActive(false);
        selection_despertar.SetActive(true);
    }

    public void ExitHover()
    {
        selection_5min.SetActive(false);
        selection_despertar.SetActive(false);
    }

    public void FiveMore()
    {
        panel.SetActive(false);
        dialogueBed.PlayerChoseFiveMore();
    }

    public void WakeUp()
    {
        panel.SetActive(false);
        dialogueBed.PlayerChoseWakeUp();
    }
}
