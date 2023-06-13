using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject PlayButton;

    public TMP_Text RemainingPoints;

    public TMP_Text CurrentLevel;

    private PlayerClass PC;

    private void Start()
    {
        PC = GameObject.Find("Player").GetComponent<PlayerClass>();
    }

    private void Update()
    {
        if(this.GetComponent<GameManager>().Player.CurrentPlayerState == PlayerHandler.PlayerState.Ready)
        {
            PlayButton.SetActive(true);
        }
        else
        {
            PlayButton.SetActive(false);
        }

        RemainingPoints.text = "AP: " + PC.ActionPoints.ToString();

        CurrentLevel.text = (SceneManager.GetActiveScene().buildIndex.ToString() + "/" + (SceneManager.sceneCountInBuildSettings - 2).ToString());
    }
}
