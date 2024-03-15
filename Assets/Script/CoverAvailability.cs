using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class CoverAvailability : MonoBehaviour
{
    [NaughtyAttributes.ReadOnly] public NodeInfo nodeInfo;
    public NodeReader nodeReader;
    public TMP_Text coverText;

    private void Awake()
    {
        nodeInfo = GetComponent<NodeInfo>();
    }

    private void Update()
    {
        if (nodeReader.dataFromOPCUANode == "False")
        {
            coverText.text = "Empty";
            coverText.color = Color.red;
        }
        else {
            coverText.text = "Good";
            coverText.color = Color.green;
        }
    }
}
