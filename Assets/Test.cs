using System.Collections;
using System.Collections.Generic;
using TwinCAT.TypeSystem;
using UnityEngine;
using realvirtual;

public class Test : MonoBehaviour
{
    public Transform position;
    public float tSpeed = 1f;        // tSpeed value with an intuitive incremental input

    [ReadOnly]
    public float lerpDuration;

    private void Start()
    {
        lerpDuration = 1000 / tSpeed;    // converts the tSpeed value 
    }

    void Update()
    {
        StartCoroutine(Lerp());
    }

    IEnumerator Lerp()
    {
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(transform.position, position.position, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = position.position;
    }
}
