using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Stores an array of all slots for active items and allows Adding and Removing from this storage.
 */
public class TravellingProductIDManager : MonoBehaviour
{
    public Item itemPrefab;
    public Item[] items = new Item[13];

    public void AddItem(int id, Transform t, ItemPositionUpdater node)
    {
        if (id < 1 || id > 12) { Debug.LogError("Cannot add an item out of bounds of the array size."); }
        Item item = CreateProductReference(t);
        items[id] = item;
        item.currentNode = node;
    }

    public void RemoveItem(int id)
    {
        if (items[id] != null)
        {
            Destroy(items[id]);
            items[id] = null;
        }
        else {
            Debug.Log("No item with id = " + id);
        }
    }

    public bool IsItemNew(int id) { 
        if (items[id] == null) { return true; }
        return false;
    }

    // Provides an object when another script wants to add an item. To be called inside AddItem()
    public Item CreateProductReference(Transform t) {
        return Instantiate(itemPrefab, t.position, t.rotation);
    }

}
