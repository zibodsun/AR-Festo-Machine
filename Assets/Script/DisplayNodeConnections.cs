using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 *  Displays a text on top of the screen which indicates which nodes have successfully connected to the interface.
 */
public class DisplayNodeConnections : MonoBehaviour
{
    public TMP_Text textBox;
    public int totalNodesCount = 12;

    int countNodes;

    private void Start()
    {
        textBox = GetComponent<TMP_Text>();
    }
    public void AddConnection(string id) {   
        textBox.text = "Connected to NodeID " + id;
        countNodes++;
        Debug.LogWarning(countNodes + " Nodes connected");
    }

    private void Update()
    {
        if (countNodes >= totalNodesCount) {
            textBox.text = "All nodes connected.";
        }
    }
}