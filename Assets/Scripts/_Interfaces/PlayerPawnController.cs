using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerPawnController
{
    [SerializeField]
    protected IControlTarget defaultControlTarget;
    protected IControlTarget currentControlTarget;
    public void ChangeControlTarget(IControlTarget controlTarget)
    {
        currentControlTarget = controlTarget;
    }
    public void RestoreControltarget()
    {
        currentControlTarget = defaultControlTarget;
    }
}


public interface IControlTarget
{

}
