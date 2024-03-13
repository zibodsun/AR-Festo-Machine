using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Displays the emergency icon when the button is pressed.
 */
public class EmgDisplayUpdater : MonoBehaviour
{
    [Header("Automatic Assignment")]
    public SpriteRenderer spriteRenderer;       // Prefab of the sprite to display
    public NodeReader nodeReader;               // Node reader for the Emg Stop Pressed of the current node

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        nodeReader = GetComponent<NodeReader>();
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        if (nodeReader.dataFromOPCUANode == "False")    // reads button pressed
        {
            spriteRenderer.enabled = true;
            spriteRenderer.color = Color.red;
        }
        else if (nodeReader.dataFromOPCUANode == "True") {  // reads button unpressed NB: This does not restart the node
            spriteRenderer.color = Color.yellow;            // Icon becomes yellow to alert user to restart node
        }
    }

    // Function called when the node is reset by pressing the correct sequence on the physical panel.
    public void ResetNode() {
        spriteRenderer.enabled = false;
    }
}