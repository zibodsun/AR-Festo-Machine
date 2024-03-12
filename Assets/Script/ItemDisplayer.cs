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
    public Button iconPrefab;
    public GameObject grid;

    [NaughtyAttributes.ReadOnly]
    public List<Transform> gridLocations;
    public CurrentOrders currentOrders;
    public List<Button> itemIconDisplays;
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

        foreach (CurrentOrderJSON order in currentOrdersObjectArray) {
            itemIconDisplays.Add( Instantiate(iconPrefab, gridLocations[gridIndex].position, Quaternion.identity, this.transform) );
            UpdateGridIndex();
        }
    }

    // Adds 1 to the index of the grid.
    void UpdateGridIndex() {
        gridIndex = (gridIndex + 1) % gridLocations.Count;
    }

    void Clear() {
        foreach (Button order in itemIconDisplays)
        {
            Destroy(order.gameObject);
        }

        itemIconDisplays.Clear();
        gridIndex = 0;
    }
}
