using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, Interactable
{
    public bool hasBeenInteracted = false;
    [SerializeField] private Dialogue interactionDialogue;

    public void Interact()
    {
        hasBeenInteracted = true;
        if (interactionDialogue != null)
        {
            StartCoroutine(DialogueManager.Instance.ShowDialogue(interactionDialogue));
        }
    }

    public bool CanInteract()
    {
        return true;
    }
}
