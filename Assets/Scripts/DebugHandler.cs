using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugHandler : MonoBehaviour
{
    public TMP_Text StateText;
    public TMP_Text PlayerText;

    private GameManager GM;

    private PlayerHandler Player;

    void Start()
    {
        GM = this.GetComponent<GameManager>();
        Player = GameObject.Find("/Player").GetComponent<PlayerHandler>();
    }


    void Update()
    {
        if (GM.CurrentGameState == GameManager.GlobalGameState.Setup)
        {
            StateText.text = "Current State: SETUP";
        }
        else if (GM.CurrentGameState == GameManager.GlobalGameState.Player_Turn)
        {
            StateText.text = "Current State: Player Turn";
        }
        else if (GM.CurrentGameState == GameManager.GlobalGameState.AI_Turn)
        {
            StateText.text = "Current State: AI Turn";
        }
        else
        {
            StateText.text = "CRITICAL ERROR: CURRENT GAME STATE UNKNOWN";
        }

        if (Player.CurrentPlayerState == PlayerHandler.PlayerState.Ready)
        {
            PlayerText.text = "Player: Ready";
        }
        else if (Player.CurrentPlayerState == PlayerHandler.PlayerState.Roll)
        {
            PlayerText.text = "Player: Rolling";
        }
        else if (Player.CurrentPlayerState == PlayerHandler.PlayerState.Move)
        {
            PlayerText.text = "Player: Moving";
        }
        else if (Player.CurrentPlayerState == PlayerHandler.PlayerState.Battle)
        {
            PlayerText.text = "Player: Battling";
        }
        else
        {
            PlayerText.text = "Player: Idle";
        }
    }
}