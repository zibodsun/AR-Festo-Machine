using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceEnableCanvas : MonoBehaviour
{
    Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }
    // Update is called once per frame
    void Update()
    {
        canvas.enabled = true;
    }
}
