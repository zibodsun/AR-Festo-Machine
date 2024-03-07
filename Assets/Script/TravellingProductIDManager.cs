using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Stores an array of all slots for active items and allows Adding and Removing from this storage.
 */
public class TravellingProductIDManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject[] items = new GameObject[13];

    public void AddItem(int id, GameObject item)
    {
        if (id < 1 || id > 12) { Debug.LogError("Cannot add an item out of bounds of the array size."); }
        items[id] = item;
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
    public GameObject CreateProductReference() {
        return Instantiate(itemPrefab);
    }

}
