using Bleakwater;
using TMPro;
using UnityEngine;

public class TEST_UIHandler : MonoBehaviour
{
    TestCharacter Character;
    int StartingAP;
    int StartingHealth;

    public Transform CharacterSheet;

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

        CharacterSheet.GetChild(2).gameObject.GetComponent<TMP_Text>().text = ("Strength: " + Character.Strength);
        CharacterSheet.GetChild(3).gameObject.GetComponent<TMP_Text>().text = ("Agility: " + Character.Agility);
        CharacterSheet.GetChild(4).gameObject.GetComponent<TMP_Text>().text = ("Wisdom: " + Character.Wisdom);
        CharacterSheet.GetChild(5).gameObject.GetComponent<TMP_Text>().text = ("Focus: " + Character.Focus);
        CharacterSheet.GetChild(6).gameObject.GetComponent<TMP_Text>().text = ("Desire: " + Character.Desire);
        CharacterSheet.GetChild(7).gameObject.GetComponent<TMP_Text>().text = ("Temperance: " + Character.Temperance);
    }
}
