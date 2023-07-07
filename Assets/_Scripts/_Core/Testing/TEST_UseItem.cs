using Bleakwater;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class TEST_UseItem : MonoBehaviour
{
    public TestCharacter Char;

    public void UseItem()
    {
        IEnumerable items = Char.UseableItemInventory.GetItems();

        foreach (IUseableItem item in items)
        {
            item.Activate(Char);
            break;
        }
    }
}
