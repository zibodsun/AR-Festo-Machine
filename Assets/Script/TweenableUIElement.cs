using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TweenableUIElement : MonoBehaviour
{
    public RectTransform UIElement;

    RectTransform rectTransform;
    bool topMenuClosed;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void ToggleTopMenuClosed() {
        if (topMenuClosed) {
            UIElement.DOAnchorPosY(-40, .6f).SetEase(Ease.InOutSine);
            topMenuClosed = false;
        }
        else if(!topMenuClosed)
        {
            UIElement.DOAnchorPosY(20, .6f).SetEase(Ease.InOutSine);
            topMenuClosed = true;
        }
        flipTransform();
    }

    void flipTransform() {
        rectTransform.localScale = new Vector3(rectTransform.localScale.x * -1, rectTransform.localScale.y, rectTransform.localScale.z);
    }

    private void Start()
    {
        
    }
}
