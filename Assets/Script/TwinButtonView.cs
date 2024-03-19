using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwinButtonView : MonoBehaviour
{
    [NaughtyAttributes.ReadOnly] public Button button;
    public Transform lookPosition;
    public Camera twinViewCamera;

    public Vector3 offset = new Vector3 (-1, 0, 0);

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SwitchView);
    }

    public void SwitchView() {
        twinViewCamera.transform.position = lookPosition.position + offset;
        twinViewCamera.transform.LookAt(lookPosition);
    }
}
