using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 *  Displays a text on top of the screen which indicates which nodes have successfully connected to the interface.
 */
public class DisplayNodeConnections : MonoBehaviour
{
    public TMP_Text textBox;                // output of the connection display string
    public int totalNodesCount = 12;        // number of nodes required to be connected

    int countNodes;                         // counter for the number of connected nodes

    private void Start()
    {
        textBox = GetComponent<TMP_Text>();
    }

    // Called when a connection to one node is completed
    public void AddConnection(string id) {   
        textBox.text = "Connected to NodeID " + id;
        countNodes++;
        Debug.LogWarning(countNodes + " Nodes connected");
    }

    private void Update()
    {
        // Checks when the max amount of nodes have connected
        if (countNodes >= totalNodesCount) {
            textBox.text = "All nodes connected.";
        }
    }
}