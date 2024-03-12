using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Reads data from the node reader to recognise a restart action after an emergency stop.
 */
public class Start : MonoBehaviour
{
    [Header("Automatic Assignment")]
    public EmgDisplayUpdater emgReader; // Script that manages the emergency icon display
    public NodeReader startReader;      // Node that detects the press of the start button

    public NodeReader resetReader;      // Node that detects the press of the reset button

    bool hasReset;                      // Whether the reset button has already been pressed

    private void Awake()
    {
        emgReader = transform.parent.GetComponent<EmgDisplayUpdater>();
        startReader = GetComponent<NodeReader>();
    }

    private void Update()
    {
        // detects the press of the reset button
        if (resetReader.dataFromOPCUANode == "True") { 
            hasReset = true;
        }

        // detects the press of teh start button after the reset button has been pressed
        if (startReader.dataFromOPCUANode == "True" && hasReset) {
            emgReader.ResetNode();      // restart the node
        }
    }
}