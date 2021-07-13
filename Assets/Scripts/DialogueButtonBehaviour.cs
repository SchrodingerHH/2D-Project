using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButtonBehaviour : MonoBehaviour
{
    public int nextNode;
    private Dialogueinteractable DI;



    void Start()
    {
        DI = GameObject.Find("Canvas").GetComponent<Dialogueinteractable>();
    }

    public void toNextNode()
    {
        DI.DialogueSwitch(nextNode);
    }
}
