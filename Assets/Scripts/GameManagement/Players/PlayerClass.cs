using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    public PlayerTemplate Class;

    private PlayerHandler Handler;

    private GameManager GM;

    [SerializeField]
    private List<PlayerTemplate> Classes = new List<PlayerTemplate>();

    public int MaxHealth;
    public int CurrentHealth;
    public int ActionPoints;

    public int CurrentStrength;
    public int CurrentAgility;
    public int CurrentMindfulness;
    public int CurrentDarkness;
    public int CurrentFocus;

    private void Awake()
    {
        Handler = GameObject.Find("/Player").GetComponent<PlayerHandler>();
        GM = GameObject.Find("/GameManagerObject").GetComponent<GameManager>();
    }

    void Start()
    {
        RollAllStats();
        CurrentHealth = MaxHealth;
    }


    void Update()
    {

    }

    public void RollAllStats()
    {
        List<int> Values = new List<int>();

        for (int i = 0; i < 5; i++)
        {
            int newVal = Random.Range(1, 7);

            Values.Add(newVal);
        }

        /*for (int i = 0; i < Values.Count; i++)
        {
            Debug.Log("Roll: " + (i) + "/" + (Values.Count) + ": " + Values[i].ToString());
        }*/

        CurrentStrength = Class.BaseStrength + Values[0];
        CurrentAgility = Class.BaseAgility + Values[1];
        CurrentMindfulness = Class.BaseMindfulness + Values[2];
        CurrentDarkness = Class.BaseDarkness + Values[3];
        CurrentFocus = Class.BaseFocus + Values[4];

        MaxHealth = Class.BaseHealth + (CurrentStrength * CurrentMindfulness);
    }

    public void GetAP()
    {
        int FinalAP = 0;

        //Choose amount of rolls
        int RollAmount = Random.Range(1, CurrentFocus);
        Debug.Log("Rolling: " + RollAmount + " times!");

        //Get final roll value
        int RollValue = 0;

        for (int i = 0; i < RollAmount; i++)
        {
            RollValue = Random.Range(1, 7);
        }

        Debug.Log("Value: " + RollValue);

        //Calculate AP
        FinalAP = ((CurrentAgility / 2) * RollValue);

        ActionPoints = GM.LevelAP;
        Handler.SpacesToMove = ActionPoints;
    }
}
