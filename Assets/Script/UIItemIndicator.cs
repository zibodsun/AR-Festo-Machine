using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/*
 *  Stores the text box of a UI element to represent the order ID
 */
public class UIItemIndicator : MonoBehaviour
{
    public TMP_Text ONo;
    public TMP_Text timeLeft;

    [NaughtyAttributes.ReadOnly] public TravellingProductIDManager productManager;
    [NaughtyAttributes.ReadOnly] public Cart cart;
    private Button btn;
    private string carrierID;

    private void Awake()
    {
        btn = GetComponent<Button>();
        productManager = FindAnyObjectByType<TravellingProductIDManager>();
        cart = FindAnyObjectByType<Cart>();

        btn.onClick.AddListener(HighlightItem);
    }

    void HighlightItem() {

        cart.GetCart();
        Debug.Log("Item Script -> " + carrierID);
        // Find carrier ID from order number
        if(carrierID == null)
        {
            Debug.Log("Carrier is null");
            foreach (CartJSON item in cart.cartObjectArray)
            {
                if (item.ONo == ONo.text)
                {
                    Debug.Log("ASsigned carreir");
                    carrierID = item.CarrierID;
                }
            }
        }

        productManager.Highlight(int.Parse(carrierID));
    }

}
