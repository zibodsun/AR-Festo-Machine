using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
