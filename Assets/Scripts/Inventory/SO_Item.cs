using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Create New Item", order = 1)]
public class SO_Item : ScriptableObject
{
    public string id;
    public string itemName;
    public string description;
    public int maxStack;

    [Header("In Game Object")]
    public GameObject gamePrefab;
}
