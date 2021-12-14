using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public Transform itemsParent;

    Inventory inventory;

    InventorySlot[] slots;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        //Calls UpdateUI method any time an item is added or removed from the inventory.
        inventory.onItemChangedCallback += UpdateUI;
        //Creates an array containing all of the item slot components.
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        
    }
}
