using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class ItemPositionUpdater : MonoBehaviour
{
    [Header("Automatic Assignment")]
    public TravellingProductIDManager productIDManager;
    public NodeReader nodeReader;

    [Header("Sensor Information")]
    public Transform readPosition;

    int productID;

    private void Start()
    {
        productIDManager = FindObjectOfType<TravellingProductIDManager>();
        nodeReader = GetComponent<NodeReader>();
    }

    private void Update()
    {
        if (nodeReader.nodeChanged) { 
            nodeReader.nodeChanged = false;

            try
            {
                productID = Int32.Parse(nodeReader.dataFromOPCUANode);
            }
            catch (FormatException e)
            {
                Debug.LogError("CANNOT PARSE -" + nodeReader.dataFromOPCUANode + "- to Int32.");
            }

            if (productIDManager.IsItemNew(productID))
            {
                productIDManager.AddItem(productID, productIDManager.CreateProductReference());
            }
            else { 
                // Update Position
            }
        }
    }

}
