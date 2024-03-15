using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Displays the emergency icon when the button is pressed.
 */
public class EmgDisplayUpdater : MonoBehaviour
{
    public enum State { 
        Active,
        Stopped,
        Reset
    }

    [Header("Automatic Assignment")]
    public SpriteRenderer spriteRenderer;       // Prefab of the sprite to display
    public NodeReader nodeReader;               // Node reader for the Emg Stop Pressed of the current node

    public State state;
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        nodeReader = GetComponent<NodeReader>();
        spriteRenderer.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (nodeReader.dataFromOPCUANode == "False")    // reads button pressed
        {
            spriteRenderer.gameObject.SetActive(true);
            spriteRenderer.color = Color.red;
            state = State.Stopped;
        }
        else if (nodeReader.dataFromOPCUANode == "True") {  // reads button unpressed NB: This does not restart the node
            spriteRenderer.color = Color.yellow;            // Icon becomes yellow to alert user to restart node
        }
    }

    // Function called when the node is reset by pressing the correct sequence on the physical panel.
    public void ResetNode() {
        spriteRenderer.gameObject.SetActive(false);
    }
}