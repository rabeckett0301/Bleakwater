using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerPrefab;

    public int LevelAP;

    public PlayerHandler Player;
    public PlayerClass PC;
    private GameObject AI;

    private int TurnCount;

    public enum GlobalGameState
    {
        Init,
        Setup,
        Player_Turn,
        AI_Turn
    }

    public GlobalGameState CurrentGameState;

    void Start()
    {
        CurrentGameState = GlobalGameState.Init;

        Player = GameObject.Find("/Player").GetComponent<PlayerHandler>();
        PC = GameObject.Find("/Player").GetComponent<PlayerClass>();

        TurnCount = 0;

        ChangeState(GlobalGameState.Setup);
    }


    void Update()
    {

    }

    public void ChangeState(GlobalGameState NextState)
    {
        if(NextState == CurrentGameState) return;

        CurrentGameState = NextState;

        switch (NextState)    
        {  
            case GlobalGameState.Setup:    
                SetUpGameSession();   
                break;
            
            case GlobalGameState.Player_Turn:  
                StartPlayerTurn();   
                break;
                
            case GlobalGameState.AI_Turn:       
                break;
        }

        //Debug.Log("State Change Over");
    }

    private void SetUpGameSession()
    {
        Debug.Log("Setting up game session...");
        //AI = GameObject.Find("AI");


        Debug.Log("Setup complete! Starting Player turn...");
        ChangeState(GlobalGameState.Player_Turn);
    }

    private void StartPlayerTurn()
    {
        TurnCount += 1;

        Debug.Log("Turn: " + TurnCount);

        Player.ChangeState(PlayerHandler.PlayerState.Ready);
    }
}
