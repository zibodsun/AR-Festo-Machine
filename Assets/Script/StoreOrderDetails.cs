using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *  Stores the selections of the order panel
 */
public class StoreOrderDetails : MonoBehaviour
{
    public SendOrder sendOrder;     // reference to the script which sends the web request to make an order
    public Dropdown dropdown;       // dropdown menu to select the product code

    private void Awake()
    {
        dropdown = GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener(SetPartNum);
    }

    // Reads the selection from the dropdown menu
    public void SetPartNum(int o) {
        switch (o) {
            case 0:
                sendOrder.partNumber = "210";
                break;
            case 1:
                break;
        }
    }
}
