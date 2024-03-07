using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 *  Displays a text on top of the screen which indicates which nodes have successfully connected to the interface.
 */
public class DisplayNodeConnections : MonoBehaviour
{
    public TMPro.TextMeshPro textBox;
    public int totalNodesCount = 12;

    int countNodes;
    public void AddConnection(string id) {
        textBox.text = "Connected to NodeID " + id;
        countNodes++;
    }

    private void Update()
    {
        if (countNodes >= totalNodesCount) {
            textBox.text = "All nodes connected.";
        }
    }
}