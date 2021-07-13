using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogueinteractable : MonoBehaviour
{
    public string playerName;
    public string questTarget;

    public GameObject button;
    public GameObject dialogueButtons;
    public GameObject dialogueSkipButton;

    public Text DialogueText;
    public TextAsset xmlDialogue;
    private DialogueSystem DS;

    private int index = 0;
    private bool isButtonCreated = false;

    private List<GameObject> currentButtons;

    void Start()
    {
        DS = DialogueSystem.GetDialogue(xmlDialogue);
        currentButtons = new List<GameObject>();
        playerName = PlayerPrefs.GetString("playerName");
    }


    void Update()
    {
        if (DS.nodes[index].endnode != "true" && isButtonCreated == false)
        {
            dialogueSkipButton.SetActive(false);
            Debug.Log(DS.nodes[index].answers.Length);
            for (int i = 0; i < DS.nodes[index].answers.Length ; i++)
            {
                GameObject currentButton = Instantiate(button, dialogueButtons.transform.position, Quaternion.identity);
                currentButton.transform.SetParent(dialogueButtons.transform);
                currentButton.GetComponentInChildren<Text>().text = DS.nodes[index].answers[i].answerText;
                currentButton.GetComponent<DialogueButtonBehaviour>().nextNode = DS.nodes[index].answers[i].toNode;
                currentButtons.Add(currentButton);
                isButtonCreated = true;
            }
        }
        else if (DS.nodes[index].endnode == "true")
        {
            foreach (GameObject item in currentButtons)
            {
                Destroy(item);
                //item.SetActive(false);
            }
            dialogueSkipButton.SetActive(true);
        }

        DialogueText.text = DS.nodes[index].text;
        TextReplacer();
    }

    private void TextReplacer()
    {
        Debug.Log("TextReplacer вызван");
        if (DialogueText.text.Contains("$name$"))
        {
            DialogueText.text = DialogueText.text.Replace("$name$", playerName);
        }
        if (DialogueText.text.Contains("$questCounter$"))
        {
            DialogueText.text = DialogueText.text.Replace("$questCounter$", LevelManager.instance.boxTargets.Count.ToString());
        }
        if (DialogueText.text.Contains("$questTarget$"))
        {
            DialogueText.text = DialogueText.text.Replace("$questTarget$", questTarget);
        }
    }

    public void DialogueSwitch(int nextNode)
    {
        if (index < DS.nodes.Length-1)
        {
            if (DS.nodes[index].endnode != "true")
            {
                index = nextNode;
            }
            else
            {
                index++;
            }
        }
        else
        {
            index = 0;
        }
        isButtonCreated = false;
    }
}
