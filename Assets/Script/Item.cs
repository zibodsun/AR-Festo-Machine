using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

/*
 *  A virtual representation of an order.
 */
public class Item : MonoBehaviour
{
    public int id;          // id of the pallet
    [Tooltip("Speed in which the item moves between one node to the next")]
    public float tSpeed;    // speed at which this item is moving     
    public GameObject highlight;

    [NaughtyAttributes.ReadOnly] public ItemPositionUpdater currentNode;    // the node that the item has last passed
    [NaughtyAttributes.ReadOnly] public Vector3 nextPosition;               // the position of the next node that this item is expected to travel to
    [NaughtyAttributes.ReadOnly] public float lerpDuration;                 // duration of the lerp calculated from the tSpeed
    
    TMP_Text IDText;                                                        // Textbox that displays the item ID

    private void Awake()
    {
        IDText = GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        IDText.text = id.ToString();                                        // Assign the id to the text box
        nextPosition = currentNode.nextPosition.position;                   // Update the nextPosition to travel to
    }

    // Moves item to the position of the next node in linear speed.
    public IEnumerator Lerp()
    {
        float timeElapsed = 0;
        lerpDuration = 1000 / tSpeed;                                       // converts the tSpeed value to the duration of the lerp

        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(transform.position, nextPosition, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = nextPosition;                                  
    }
}
