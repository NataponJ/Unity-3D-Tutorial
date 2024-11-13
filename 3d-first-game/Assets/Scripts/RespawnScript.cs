using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public Transform obj;
    private Transform positionOriginal;
    // Start is called before the first frame update
    void Start()
    {
        positionOriginal = obj;
    }

    // Update is called once per frame
    void Update()
    {
        if (obj.position.y < -10f)
        {
            obj.position = new Vector3(positionOriginal.position.x, positionOriginal.position.y, positionOriginal.position.z);
            Physics.autoSyncTransforms = true;
        }
    }
}
