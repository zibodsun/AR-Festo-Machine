using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 *  Manages the active virtual items. When there is a new read in a node, this script checks if there is a need to update 
 *  the data in the TravellingProductIDManager.
 */
public class ItemPositionUpdater : MonoBehaviour
{
    [Header("Automatic Assignment")]
    public TravellingProductIDManager productIDManager;
    public NodeReader nodeReader;

    [Header("Sensor Information")]
    [Tooltip("The sensor that is expected to come after this one.")]
    public Transform nextPosition;
    public float speedToNextPosition;

    int productID;

    private void Start()
    {
        productIDManager = FindObjectOfType<TravellingProductIDManager>();
        nodeReader = GetComponent<NodeReader>();

        transform.LookAt(nextPosition);
    }

    private void Update()
    {
        if (nodeReader.nodeChanged) {
            nodeReader.nodeChanged = false;

            if ( Int32.TryParse(nodeReader.dataFromOPCUANode, out productID) == false )
            {
                Debug.LogError("CANNOT PARSE -" + nodeReader.dataFromOPCUANode + "- to Int32.");
                return;
            }
            
            if (productIDManager.IsItemNew(productID))                  // Check if it is the first time reading the product ID
            {
                // Spawns a new Item at the location of this node
                productIDManager.AddItem(productID, transform, this);
                productIDManager.items[productID].tSpeed = speedToNextPosition;

            }
            else {
                // Updates the position of the ID to be the current one
                //productIDManager.items[productID].transform.position = readPosition.position;
                //productIDManager.items[productID].MoveTo(readPosition.position);
                productIDManager.items[productID].currentNode = this;
                productIDManager.items[productID].tSpeed = speedToNextPosition;
            }
        }
    }

}
