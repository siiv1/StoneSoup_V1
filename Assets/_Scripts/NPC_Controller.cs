using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour, Interactable
{
    [SerializeField] Dialogue dialogue;
    [SerializeField] private GameObject requiredObject; // Object that must be interacted with first
    [SerializeField] private Dialogue alternateDialogue; // Dialogue to show if condition isn't met
    public void Interact()
    {
        // Check if the required object was interacted with
        if (requiredObject != null && !requiredObject.GetComponent<InteractableObject>().hasBeenInteracted)
        {
            if (alternateDialogue != null)
            {
                StartCoroutine(DialogueManager.Instance.ShowDialogue(alternateDialogue));
            }
            else
            {
                Debug.Log("You need to interact with " + requiredObject.name + " first.");
            }
            return;
        }
        StartCoroutine(DialogueManager.Instance.ShowDialogue(dialogue));
    }
    public bool CanInteract()
    {
        return true; // Allows interaction at all times
    }

}
