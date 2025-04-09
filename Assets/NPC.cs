using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour, Interactable
{
    public NPCDialogue dialogueData;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;
    public Image portraitImage;

    private int dialogueIndex;
    private bool isTyping, isDialogueActive;

    public bool CanInteract()
    {
        return !isDialogueActive;
    }

    public void Interact()
    {
        //If no Dialogue data or the game is paused and no dialogue is active
        if (dialogueData == null) /*|| (PauseController.IsGamePaused && !isDialogueActive8))*/
            return;

        if (isDialogueActive)
        {
            NextLine();

        }
        else
        {
            StartDialogue();
        }
    }
    void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;

        nameText.SetText(dialogueData.npcName);
        portraitImage.sprite = dialogueData.npcPortrait;

        dialoguePanel.SetActive(true);
        //UPDATE THIS PauseController.SetPause(true);

        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (isTyping)
        {
            //THis is for skipping the typing animation to the next line
            StopAllCoroutines();
            dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;
        }
        else if(++dialogueIndex < dialogueData.dialogueLines.Length)
        {
            //If theres another line...type it
            StartCoroutine(TypeLine());
        }
        else{
            EndDialogue();
        }
    }
    public IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText ("");

        foreach (char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }

        isTyping = false;

        if(dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData
            .autoProgressLines[dialogueIndex])
        {
            yield return new WaitForSeconds(dialogueData.autoProgressDelay);
            NextLine();
        }
    }
    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
        //PauseController.SetPause(false);
    }
}
 