using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerEnd : MonoBehaviour
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
        FindObjectOfType<DialogueManagerEnd>().StartDialogue(dialogue);
    }
    void OnTriggerEnter(Collider other)
    {
        TriggerDialogue();
        boxCollider.enabled = false;
    }
    void Update()
    {
        if (EnemyCounter.complete)
        {
            boxCollider.enabled = true;

        }
    }
}
