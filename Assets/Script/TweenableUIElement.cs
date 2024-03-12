using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/*
 *  Moves a UI element using Tween
 */
public class TweenableUIElement : MonoBehaviour
{
    public RectTransform UIElement;     // The transform to be tweened

    RectTransform rectTransform;        // The transform of the object this script is attached to
    bool topMenuClosed;                 // Whether the top menu has been closed
    bool sideMenuClosed;                // Whether the side menu has been closed

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Tweens the top menu on the Y axis
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
        flipTransform();    // flip the arrow icon
    }
    
    // Tweens the side menu on the X axis
    public void ToggleSideMenuClosed()
    {
        if (sideMenuClosed)
        {
            UIElement.DOAnchorPosX(115, .6f).SetEase(Ease.InOutSine);
            sideMenuClosed = false;
        }
        else if (!sideMenuClosed)
        {
            UIElement.DOAnchorPosX(-95, .6f).SetEase(Ease.InOutSine);
            sideMenuClosed = true;
        }
        flipTransform();    // flip the arrow icon
    }

    // Flip a transform on the x axis
    void flipTransform() {
        rectTransform.localScale = new Vector3(rectTransform.localScale.x * -1, rectTransform.localScale.y, rectTransform.localScale.z);
    }
}
