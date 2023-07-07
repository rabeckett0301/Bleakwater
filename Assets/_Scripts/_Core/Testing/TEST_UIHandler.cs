using Bleakwater;
using TMPro;
using UnityEngine;

public class TEST_UIHandler : MonoBehaviour
{
    TestCharacter Character;
    int StartingAP;
    int StartingHealth;

    void Start()
    {
        Character = GameObject.Find("CharacterTest").GetComponent<TestCharacter>();
        StartingAP = Character.ActionPoints;
        StartingHealth = Character.Health;
    }

    void Update()
    {
        this.transform.GetChild(5).gameObject.GetComponent<TMP_Text>().text = ("AP: " + Character.ActionPoints + "/" + StartingAP);
        this.transform.GetChild(4).gameObject.GetComponent<TMP_Text>().text = ("Health: " + Character.Health + "/" + StartingHealth);
    }
}
