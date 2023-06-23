using Bleakwater;
using TMPro;
using UnityEngine;

public class TEST_UIHandler : MonoBehaviour
{
    TestCharacter Character;
    int StartingAP;

    void Start()
    {
        Character = GameObject.Find("CharacterTest").GetComponent<TestCharacter>();
        StartingAP = Character.ActionPoints;
    }

    void Update()
    {
        this.transform.GetChild(4).gameObject.GetComponent<TMP_Text>().text = ("AP: " + Character.ActionPoints + "/" + StartingAP);
    }
}
