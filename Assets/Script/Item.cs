using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

/*
 *  A virtual representation of an order.
 */
public class Item : MonoBehaviour
{
    public int id;
    [Tooltip("Speed in which the item moves between one node to the next")]
    public float tSpeed = 0.04f;

    [NaughtyAttributes.ReadOnly] public ItemPositionUpdater currentNode;
    [NaughtyAttributes.ReadOnly] public Vector3 nextPosition;

    private void Update()
    {
        nextPosition = currentNode.nextPosition.position;
        transform.position = Vector3.Lerp(transform.position, nextPosition, tSpeed * Time.deltaTime);
    }
    /* public void MoveTo(Vector3 b) {
        nextPosition = b;
    } */
}
