using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

/*
 *  A virtual representation of an order.
 */
public class Item : MonoBehaviour
{
    public int id;
    [Tooltip("Speed in which the item moves between one node to the next")]
    public float tSpeed = 1f;    // tSpeed value with an intuitive incremental input     

    [NaughtyAttributes.ReadOnly] public ItemPositionUpdater currentNode;
    [NaughtyAttributes.ReadOnly] public Vector3 nextPosition;
    [NaughtyAttributes.ReadOnly] public float lerpDuration;

    private void Start()
    {
        lerpDuration = 1000 / tSpeed;    // converts the tSpeed value 
    }

    private void Update()
    {
        nextPosition = currentNode.nextPosition.position;
        StartCoroutine(Lerp());
    }

    // Moves item to the position of the next node in linear speed.
    IEnumerator Lerp()
    {
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(transform.position, nextPosition, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = nextPosition;
    }
}
