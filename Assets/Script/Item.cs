using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public float tSpeed = 0.04f;

    public ItemPositionUpdater currentNode;
    public Vector3 nextPosition;

    private void Update()
    {
        nextPosition = currentNode.nextPosition.position;
        transform.position = Vector3.Lerp(transform.position, nextPosition, tSpeed * Time.deltaTime);
    }
    public void MoveTo(Vector3 b) {
        nextPosition = b;
    }
}
