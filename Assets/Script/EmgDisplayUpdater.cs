using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Displays the emergency icon when the button is pressed.
 */
public class EmgDisplayUpdater : MonoBehaviour
{
    [Header("Automatic Assignment")]
    public SpriteRenderer spriteRenderer;
    public NodeReader nodeReader;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        nodeReader = GetComponent<NodeReader>();
    }

    private void Update()
    {
        if (nodeReader.dataFromOPCUANode == "True")
        {
            spriteRenderer.enabled = true;
        }
    }

    // Function called when the node is reset by pressing the correct sequence on the physical panel.
    public void ResetNode() {
        spriteRenderer.enabled = false;
    }
}
