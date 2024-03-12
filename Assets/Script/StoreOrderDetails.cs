using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreOrderDetails : MonoBehaviour
{
    public SendOrder sendOrder;
    public Dropdown dropdown;

    private void Awake()
    {
        dropdown = GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener(SetPartNum);
    }

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
