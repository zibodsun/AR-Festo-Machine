using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSimulation : MonoBehaviour
{
    public GameObject fireSimulationEffects;

    private void Start()
    {
        fireSimulationEffects.SetActive(true);
    }
}
