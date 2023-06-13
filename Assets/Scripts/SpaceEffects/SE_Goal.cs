using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[CreateAssetMenu(fileName = "Space", menuName = "Spaces/Goal Space", order = 1)]

public class SE_Goal : SpaceTemplate
{
    public override void ActivateSpaceEffect(PlayerClass AffectedPlayer)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
