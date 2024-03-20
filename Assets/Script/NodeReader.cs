using UnityEngine;
using realvirtual;
using Unity.VisualScripting;

public class NodeReader : MonoBehaviour
{
    [Header("Factory Machine")]
    public int factoryMachineID;
    public OPCUA_Interface oPCUAInterface;

    [Header("OPCUA Reader")]
    public string nodeBeingMonitored;
    public string nodeID;
    public string dataFromOPCUANode;

    //[ReadOnly]
    public bool nodeChanged;

    public DisplayNodeConnections connectionDisplay;

    // Subscribe to OPC UA events on start
    void Start()
    {
        oPCUAInterface.EventOnConnected.AddListener(OnInterfaceConnected);
        oPCUAInterface.EventOnDisconnected.AddListener(OnInterfaceDisconnected);
    }

    // Method called when the OPC UA interface is connected
    private void OnInterfaceConnected()
    {
        // Subscribe to the specified node and provide the method to call on node change
        var subscription = oPCUAInterface.Subscribe(nodeID, NodeChanged);
        dataFromOPCUANode = subscription.ToString();

        Debug.Log("Connected to Factory Machine " + factoryMachineID);
        Debug.Log(dataFromOPCUANode);
        if (connectionDisplay != null)
        {
            connectionDisplay.AddConnection(factoryMachineID.ToString());
        }
        else {
            Debug.LogWarning("No connection display assigned");
        }
    }

    // Method called when the OPC UA interface is disconnected
    private void OnInterfaceDisconnected()
    {
        Debug.LogWarning("Factory Machine " + factoryMachineID + " has disconnected");
    }

    // Method called when the monitored node changes its value
    public void NodeChanged(OPCUANodeSubscription sub, object value)
    {
        nodeChanged = true;

        if (nodeBeingMonitored == "Emg Stop Pressed" ||
            nodeBeingMonitored == "RFID In" ||
            nodeBeingMonitored == "RFID In Twin" ||
            nodeBeingMonitored == "G1 Passed" ||
            nodeBeingMonitored == "Reset" ||
            nodeBeingMonitored == "Start" ||
            nodeBeingMonitored == "CoverStorage")
        {                                                                      
            dataFromOPCUANode = value.ToString();
        }
    }
}
