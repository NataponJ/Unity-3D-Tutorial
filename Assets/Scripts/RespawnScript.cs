using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    private float minthreshold = -10.0f;
    private float maxthreshold = 100.0f;
    private Vector3 defaultPosition;

    private void Start()
    {
        defaultPosition = transform.position;
    }
    private void FixedUpdate()
    {
        if (transform.position.y < minthreshold || transform.position.y > maxthreshold)
        {
            transform.position = new Vector3(defaultPosition.x, defaultPosition.y, defaultPosition.z);
        }
    }
}
