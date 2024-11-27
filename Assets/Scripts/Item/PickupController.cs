using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    private void OnTriggerStay(Collider target)
    {
        if (target.gameObject.tag.Equals("Item") && Input.GetKey("e"))
        {
            Destroy(target.gameObject);
        }
    }
}
