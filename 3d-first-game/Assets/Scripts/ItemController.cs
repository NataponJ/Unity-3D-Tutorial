using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public SO_Item item;
    public int amount = 1;
    private float rotateSpeed = 100f;

    public void SetAmount(int newAmount)
    {
        amount = newAmount;
    }

    public void RandomAmount(int newAmount)
    {
        amount = Random.Range(0, item.maxStack);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
