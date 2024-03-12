using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using Unity.VisualScripting;

/*
 *  Displays items that are active in a side panel with icons.
 */
public class ItemDisplayer : MonoBehaviour
{
    public UIItemIndicator iconPrefab;
    public GameObject grid;

    [NaughtyAttributes.ReadOnly]
    public List<Transform> gridLocations;
    public CurrentOrders currentOrders;
    public List<UIItemIndicator> itemIconDisplays;
    int gridIndex = 0;

    private void Awake()
    {
        currentOrders = GetComponent<CurrentOrders>();
        foreach (Transform child in grid.transform) {
            gridLocations.Add(child);
        }
    }
    private void Update()
    {
        
    }

    public void DisplayItemInMenu(CurrentOrderJSON[] currentOrdersObjectArray) {
        Clear();
        UIItemIndicator newItem;

        foreach (CurrentOrderJSON order in currentOrdersObjectArray) {
            newItem = ( Instantiate(iconPrefab, gridLocations[gridIndex].position, Quaternion.identity, this.transform) );
            newItem.text.text = order.ONo.ToString();
            
            itemIconDisplays.Add(newItem);
            UpdateGridIndex();
        }
    }

    // Adds 1 to the index of the grid.
    void UpdateGridIndex() {
        gridIndex = (gridIndex + 1) % gridLocations.Count;
    }

    void Clear() {
        foreach (UIItemIndicator order in itemIconDisplays)
        {
            Destroy(order.gameObject);
        }

        itemIconDisplays.Clear();
        gridIndex = 0;
    }
}
