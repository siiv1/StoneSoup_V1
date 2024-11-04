using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {FreeRoam, Dialog }
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerMovement playerController;
    GameState state;
    private void Start()
    {
        DialogueManager.Instance.OnShowDialogue += () =>
        {
            state = GameState.Dialog;
        };
        DialogueManager.Instance.OnHideDialogue += () =>
        {
            if (state == GameState.Dialog)
            {
                state = GameState.FreeRoam;
            }
        };
    }

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();

        }else if (state == GameState.Dialog)
        {
            DialogueManager.Instance.HandleUpdate();
        }
    }
}
