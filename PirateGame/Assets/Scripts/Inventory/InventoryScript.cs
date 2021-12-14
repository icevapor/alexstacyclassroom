using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public GameObject inventoryUI;

    public Item item;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!inventoryUI.activeSelf)
            {
                openInventory();
            }

            else
            {
                exitInventory();
            }
        }

        //Adding hammer to inventory for testing purposes
        if (Input.GetKeyDown(KeyCode.H))
        {
            Inventory.instance.addItem(item);
        }
    }

    public void exitInventory()
    {
        Time.timeScale = 1;
        inventoryUI.SetActive(false);
    }

    public void openInventory()
    {
        inventoryUI.SetActive(true);
        Time.timeScale = 0;
    }
}
