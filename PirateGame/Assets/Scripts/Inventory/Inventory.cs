using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    //Use Inventory.instance.Add(item); when adding items to inventory in other scripts in the future.
    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }
        instance = this;
    }

    #endregion

    //TBH I don't really understand why this is important but the resource I'm learning from said it would be important for invetory UI updates.
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int invSpace = 20;

    public List<Item> items = new List<Item>();

    public void addItem(Item item)
    {
        if (items.Count >= invSpace)
        {
            Debug.Log("Not enough space in inventory.");
            return;
        }
        items.Add(item);
        Debug.Log("Adding item to inventory...");
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void removeItem(Item item)
    {
        items.Remove(item);
        Debug.Log("Removing item from inventory...");
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
