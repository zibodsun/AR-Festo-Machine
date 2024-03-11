using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    [Header("Automatic Assignment")]
    public EmgDisplayUpdater emgReader;
    public NodeReader startReader;

    public NodeReader resetReader;

    bool hasReset;

    private void Awake()
    {
        emgReader = transform.parent.GetComponent<EmgDisplayUpdater>();
        startReader = GetComponent<NodeReader>();
    }

    private void Update()
    {
        if (resetReader.dataFromOPCUANode == "True") { 
            hasReset = true;
        }

        if (startReader.dataFromOPCUANode == "True" && hasReset) {
            emgReader.ResetNode();
        }
    }
}