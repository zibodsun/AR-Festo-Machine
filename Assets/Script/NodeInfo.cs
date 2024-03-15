using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NodeInfo : MonoBehaviour
{
    public NodeReader RFIDReader;
    public EmgDisplayUpdater EMGBtnReader;

    [Header("Automatic Assignment")]
    public TMP_Text lastIDText;
    public TMP_Text EMGBtnText;

    private void Awake()
    {
        lastIDText = transform.GetChild(0).GetChild(2).GetComponent<TMP_Text>();  
        EMGBtnText = transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
    }

    private void Update()
    {
        lastIDText.text = RFIDReader.dataFromOPCUANode;
        EMGBtnText.text = EMGBtnReader.state.ToString();

        UpdateTextColour();
    }

    // changes colour of the status text
    private void UpdateTextColour()
    {
        switch (EMGBtnText.text) {
            case "Active":
                EMGBtnText.color = Color.green;
                break;
            case "Reset":
                EMGBtnText.color = Color.yellow;
                break;
            case "Stopped":
                EMGBtnText.color = Color.red;
                break;
        }
    }
}
