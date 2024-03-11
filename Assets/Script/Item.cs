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
    public int id;
    [Tooltip("Speed in which the item moves between one node to the next")]
    public float tSpeed;    // tSpeed value with an intuitive incremental input     

    [NaughtyAttributes.ReadOnly] public ItemPositionUpdater currentNode;
    [NaughtyAttributes.ReadOnly] public Vector3 nextPosition;
    [NaughtyAttributes.ReadOnly] public float lerpDuration;
    
    TMP_Text IDText;

    private void Awake()
    {
        IDText = GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        IDText.text = id.ToString();
        nextPosition = currentNode.nextPosition.position;
        //transform.position = Vector3.Lerp(transform.position, nextPosition, 0.5f * Time.deltaTime);
        //StartCoroutine(Lerp());
    }

    // Moves item to the position of the next node in linear speed.
    public IEnumerator Lerp()
    {
        float timeElapsed = 0;
        lerpDuration = 1000 / tSpeed;    // converts the tSpeed value 
        Debug.Log("lerp duration " + lerpDuration);
        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(transform.position, nextPosition, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = nextPosition;
    }
}
