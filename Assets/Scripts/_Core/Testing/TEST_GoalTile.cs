using Bleakwater;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_GoalTile : MonoBehaviour, ITile
{
    public void Activate()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }

    public IEnumerable<TileTag> Tags => new List<TileTag>();

    public Transform Transform => transform;

    public void Hide()
    {
        throw new System.NotImplementedException();
    }

    public void Show()
    {
        throw new System.NotImplementedException();
    }
}
