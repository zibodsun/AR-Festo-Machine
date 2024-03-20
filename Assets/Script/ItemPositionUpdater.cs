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
    public TravellingProductIDManager productIDManager;     // Script that stores the current active items
    public NodeReader nodeReader;                           // The node reader of this node

    [Header("Sensor Information")]
    [Tooltip("The sensor that is expected to come after this one.")] public Transform nextPosition;
    [Tooltip("The speed that the item will have when it travels to the next node.")] public float speedToNextPosition;

    int productID;          // stores the value of the last read product ID

    private void Start()
    {
        productIDManager = FindObjectOfType<TravellingProductIDManager>();
        nodeReader = GetComponent<NodeReader>();

        transform.LookAt(nextPosition);         // rotates the transform to face the next node
    }

    private void Update()
    {
        // When a new value is read by the node
        if (nodeReader.nodeChanged) {
            nodeReader.nodeChanged = false;

            // do nothing if we are reading a twin node and it is not active
            if (nodeReader.nodeBeingMonitored == "RFID In Twin" && !productIDManager.twinActive) {
                return;
            }

            if ( Int32.TryParse(nodeReader.dataFromOPCUANode, out productID) == false)          // Check if the read value is an int
            {
                Debug.LogError("CANNOT PARSE -" + nodeReader.dataFromOPCUANode + "- to Int32.");
                return;
            }
            
            if (productIDManager.IsItemNew(productID))                      // Check if it is the first time reading the product ID
            {
                // Spawns a new Item at the location of this node
                productIDManager.AddItem(productID, transform, this);
                productIDManager.items[productID].tSpeed = speedToNextPosition;
                StartCoroutine(productIDManager.items[productID].Lerp());


            }
            else {
                // Assigns the current node to the item that has been detected
                productIDManager.items[productID].currentNode = this;
                productIDManager.items[productID].tSpeed = speedToNextPosition;
                StartCoroutine(productIDManager.items[productID].Lerp());

            }
        }
    }
}
