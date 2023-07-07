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
    private List<Image> openSlots;//TOOD: Replace with an ordered list
    [SerializeField]
    private GameObject TargetGameObject;
    private ICharacter targetICharacter;

    private IInventory<ITileItem> _tileItemInventory;
    private IInventory<IUseableItem> _useableItemInventory;
    private IInventory<IKeyItem> _keyItemInventory;

    private BidirectionalMap<IItem, GameObject> _itemSlotPair = new();
    void Start()
    {
        targetICharacter= TargetGameObject.GetComponent<ICharacter>();
        _tileItemInventory = targetICharacter.TileItemInventory;
        _useableItemInventory = targetICharacter.UseableItemInventory;
        _keyItemInventory = targetICharacter.KeyItemInventory;
        slots = new List<Image>(_targetView.GetComponentsInChildren<Image>());

        slots.RemoveAt(0);

        ResetInv();
    }

    private void ResetInv()
    {
        foreach(var slot in slots)
        {
            if (slot != null)
            {
                GameObject target = slot.gameObject;
                EmptySlot(target);
            }
        }
        openSlots = new List<Image>(slots);

        foreach (var item in _tileItemInventory.GetItems())
        {
            FillSlot(item);
        }
        foreach (var item in _useableItemInventory.GetItems())
        {
            FillSlot(item);
        }
        foreach (var item in _keyItemInventory.GetItems())
        {
            FillSlot(item);
        }
        
    }
    private void FillSlot(IItem item)
    {
        if ((openSlots.Count>0))
        {
            _itemSlotPair.AddPair(item, openSlots[0].gameObject);
            openSlots.RemoveAt(0);
            _itemSlotPair.TryGetValueForKey(item, out GameObject slot);
            slot.GetComponent<Image>().sprite = item.Icon;
            Debug.Log("Added Slot" + slot.gameObject.name);
        }

    }
    private void EmptySlot(IItem item)
    {
        if(_itemSlotPair.TryGetValueForKey(item, out GameObject slot))
        {
            openSlots.Add(slot.GetComponent<Image>());
            slot.GetComponent<Image>().sprite = null;
            _itemSlotPair.RemoveByKey(item);
        }
    }
    private void EmptySlot(GameObject slot)
    {
        bool has = _itemSlotPair.TryGetKeyForValue(slot, out IItem item);
        if (has)
        {
            openSlots.Add(slot.GetComponent<Image>());
            slot.GetComponent<Image>().sprite = null;
            _itemSlotPair.RemoveByKey(item);
        }
    }

    private void OnItemRemoved(IItem item)
    {
        
    }
    private void OnItemAdded(IItem item)
    {

    }
    // Update is called once per frame
    void Update()
    {
        ResetInv();

    }
    private class BidirectionalMap<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _forward = new Dictionary<TKey, TValue>();
        private Dictionary<TValue, TKey> _backward = new Dictionary<TValue, TKey>();

        public bool AddPair(TKey key, TValue value)
        {
            if (!_forward.ContainsKey(key) && !_backward.ContainsKey(value))
            {
                _forward.Add(key, value);
                _backward.Add(value, key);
                return true;
            }
            return false;
        }

        public void RemoveByKey(TKey key)
        {
            if (_forward.TryGetValue(key, out TValue value))
            {
                _forward.Remove(key);
                _backward.Remove(value);
            }
        }

        public void RemoveByValue(TValue value)
        {
            if (_backward.TryGetValue(value, out TKey key))
            {
                _forward.Remove(key);
                _backward.Remove(value);
            }
        }

        public bool TryGetValueForKey(TKey key, out TValue value)
        {
            bool hasKey = _forward.TryGetValue(key, out value);
            return hasKey;
        }

        public bool TryGetKeyForValue(TValue value, out TKey key)
        {
            bool hasValue = _backward.TryGetValue(value, out key);
            return hasValue;
        }
    }
}
