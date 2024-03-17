using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using Unity.VisualScripting;
using System;
using UnityEngine.Rendering.Universal;

/*
 *  Displays items that are active in a side panel with icons.
 */
public class ItemDisplayer : MonoBehaviour
{
    public UIItemIndicator iconPrefab;              // Prefab for the Icon to be displayed
    public GameObject grid;                         // Gameobject that determines the positions of the icons

    [NaughtyAttributes.ReadOnly] public List<Transform> gridLocations;           // A list of the locations of the items
    [NaughtyAttributes.ReadOnly] public CurrentOrders currentOrders;             // Reference to the currentOrders script
    [NaughtyAttributes.ReadOnly] public List<UIItemIndicator> itemIconDisplays;  // List of orders currently active
    [NaughtyAttributes.ReadOnly] int gridIndex = 0;                              // Keeps track of the next empty position on the grid
    [NaughtyAttributes.ReadOnly] CurrentOrderJSON[] currentOrdersObjectArray;

    private void Awake()
    {
        currentOrders = GetComponent<CurrentOrders>();

        foreach (Transform child in grid.transform) {   // Add the positions of the child gameobjects to the list
            gridLocations.Add(child);
        }
    }

    // Updates the visualised items in the orders panel
    public void DisplayItemInMenu() {
        Clear();                           // Removes all items from the list
        currentOrdersObjectArray = currentOrders.currentOrdersObjectArray;
        UIItemIndicator newItem;

        foreach (CurrentOrderJSON order in currentOrdersObjectArray) {
            newItem = ( Instantiate(iconPrefab, gridLocations[gridIndex].position, Quaternion.identity, this.transform) );  // spawns all icons
            newItem.ONo.text = order.ONo.ToString();   // assigns the order ID to be displayed on the virtual item
            newItem.timeLeft.text = TimeDifference(order.PlannedEnd);

            itemIconDisplays.Add(newItem);              // adds the instantiated item to the list
            UpdateGridIndex();                          // updates the next free grid location
        }
    }

    // Adds 1 to the index of the grid.
    void UpdateGridIndex() {
        gridIndex = (gridIndex + 1) % gridLocations.Count;      // if the grid has reached the end of the list, reset to the start
    }

    // clears all item icons from the panel and list and resets the grid index
    void Clear() {
        foreach (UIItemIndicator order in itemIconDisplays)
        {
            Destroy(order.gameObject);
        }

        itemIconDisplays.Clear();
        gridIndex = 0;
    }

    string TimeDifference(string e) {
        string start = DateTime.Now.ToString().Substring(e.LastIndexOf(' ') + 1);
        string end = e.Substring(e.LastIndexOf(' ') + 1);

        TimeSpan duration = DateTime.Parse(end).Subtract(DateTime.Parse(start));
        return duration.ToString();
    }
}
