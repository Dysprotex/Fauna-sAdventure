using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        TriggerDialogue();
    }
    void OnTriggerExit(Collider other)
    {

    }
}
