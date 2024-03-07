using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

/*
 *  Displays items that are active in a side panel with icons.
 */
public class ItemDisplayer : MonoBehaviour
{
    public Button iconPrefab;
    public GameObject grid;

    [NaughtyAttributes.ReadOnly]
    public List<Transform> gridLocations;

    int gridIndex = 0;

    private void Awake()
    {
        foreach (Transform child in grid.transform) {
            gridLocations.Add(child);
        }
    }

    public void DisplayItemInMenu() {
        Instantiate(iconPrefab, gridLocations[gridIndex].position, Quaternion.identity, this.transform);
        UpdateGridIndex();
    }

    void UpdateGridIndex() {
        gridIndex = (gridIndex + 1) % gridLocations.Count;
    }
}
