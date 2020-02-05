using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public BoxCollider boxCollider;
    bool gameIsPaused = false;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    void OnTriggerEnter(Collider other)
    {
        TriggerDialogue();
        boxCollider.enabled = false;
    }
}
