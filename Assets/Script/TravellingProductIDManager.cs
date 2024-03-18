using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Stores an array of all slots for active items and allows Adding and Removing from this storage.
 */
public class TravellingProductIDManager : MonoBehaviour
{
    public Item itemPrefab;                 // Prefab for the 3D item visualised.
    public Item[] items = new Item[13];     // Array that stores each item on the index respective to the pallet ID

    int highlighted;

    // Stores a new item
    public void AddItem(int id, Transform t, ItemPositionUpdater node)
    {
        // Checks if ID is out of bounds for the array
        if (id < 1 || id > 12) { 
            Debug.LogError("Cannot add an item out of bounds of the array size. " + id);
            return;
        }

        Item item = CreateProductReference(t);  // Instantiate an item and stores it in a variable
        item.id = id;                           // Assign ID to new item
        items[id] = item;                       // Adds the item to the corresponding index in the array
        item.currentNode = node;                // Sets the current node of the item
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

    // Checks if an item ID already has an item assigned to it
    public bool IsItemNew(int id) { 
        if (items[id] == null) { return true; }
        return false;
    }

    // Creates an instance of the item prefab
    public Item CreateProductReference(Transform t) {
        return Instantiate(itemPrefab, t.position, t.rotation);
    }

    // Enables the child object of an item which shows a transparent highlight
    public void Highlight(int carrierId) {
        if (highlighted != 0)
        {
            Debug.Log("Disable " + highlighted);
            items[highlighted].highlight.SetActive(false);
        }

        items[carrierId].highlight.SetActive(true);
        highlighted = carrierId;
        Debug.Log("Enable " + highlighted);
    }
}
