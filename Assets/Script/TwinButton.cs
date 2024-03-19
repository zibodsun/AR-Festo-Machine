using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TwinButton : MonoBehaviour
{
    [Header("Automatic Assignment")]
    public TMP_Text text;
    [Space]
    public Camera ARCamera;
    public Camera twinCamera;
    public GameObject infoPanels;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Switch);
        text = GetComponentInChildren<TMP_Text>();
    }

    public void Switch() {

        if (ARCamera.gameObject.activeSelf){
            text.text = "AR";
            ARCamera.gameObject.SetActive(false);
            twinCamera.gameObject.SetActive(true);
            infoPanels.SetActive(false);
        }
        else if (twinCamera.gameObject.activeSelf) {
            text.text = "T";
            ARCamera.gameObject.SetActive(true);
            twinCamera.gameObject.SetActive(false);
            infoPanels.SetActive(true);
        }
    }
}
