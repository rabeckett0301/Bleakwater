using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestInventoryView : MonoBehaviour
{
    [SerializeField]
    private GameObject _targetView;
    [SerializeField]
    private List<Image> slots;
    [SerializeField]
    private GameObject TargetGameObject;
    private ICharacter targetICharacter;

    private IInventory<ITileItem> _tileItemInventory;
    private IInventory<IUseableItem> _useableItemInventory;
    private IInventory<IKeyItem> _keyItemInventory;
    void Start()
    {
        targetICharacter= TargetGameObject.GetComponent<ICharacter>();
        _tileItemInventory = targetICharacter.TileItemInventory;
        _useableItemInventory = targetICharacter.UseableItemInventory;
        _keyItemInventory = targetICharacter.KeyItemInventory;
        slots = new List<Image>(_targetView.GetComponentsInChildren<Image>());
        slots.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach (var item in _tileItemInventory.GetItems()) 
        {
            slots[i].sprite = item.Icon;
            i++;
        }
        foreach (var item in _useableItemInventory.GetItems())
        {
            slots[i].sprite = item.Icon;
            i++;
        }
        foreach (var item in _keyItemInventory.GetItems())
        {
            slots[i].sprite = item.Icon;
            i++;
        }
    }
}
