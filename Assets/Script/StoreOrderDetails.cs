using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*
 *  Stores the selections of the order panel
 */
public class StoreOrderDetails : MonoBehaviour
{
    public SendOrder sendOrder;     // reference to the script which sends the web request to make an order

    [Header("Automatic Assignment")]
    public TMP_Dropdown dropdown;       // dropdown menu to select the product code

    [Header("Order Icons")]
    public Image image;
    public Sprite[] icons = new Sprite[8];

    private void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.onValueChanged.AddListener(SetPartNum);
    }

    // Reads the selection from the dropdown menu
    public void SetPartNum(int o) {
        switch (o) {
            case 0:
                sendOrder.partNumber = "210";
                image.sprite = icons[0];
                break;
            case 1:
                sendOrder.partNumber = "214";
                image.sprite = icons[1];
                break;
            case 2:
                sendOrder.partNumber = "1200";
                image.sprite = icons[2];
                break;
            case 3:
                sendOrder.partNumber = "1201";
                image.sprite = icons[3];
                break;
            case 4:
                sendOrder.partNumber = "1210";
                image.sprite = icons[4];
                break;
            case 5:
                sendOrder.partNumber = "3001";
                image.sprite = icons[5];
                break;
            case 6:
                sendOrder.partNumber = "3002";
                image.sprite = icons[6];
                break;
            case 7:
                sendOrder.partNumber = "3003";
                image.sprite = icons[7];
                break;
        }
    }
}
