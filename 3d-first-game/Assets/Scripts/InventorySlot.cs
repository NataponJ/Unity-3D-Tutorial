using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("Inventory Slot")]

    public Inventory inventory;

    [Header("Slot Detail")]
    public SO_Item item;
    public int stack;

    [Header("UI")]
    public TextMeshProUGUI textMeshPro;

    public void SetSlot(SO_Item newItem, int amount)
    {
        item = newItem;
        int itemAmount = amount;
        int maxStack = newItem ? newItem.maxStack : 99;
        int inSlot = Mathf.Clamp(itemAmount, 0, maxStack);
        stack = inSlot;

        ShowText();

        int amountLeft = itemAmount - inSlot;
        if (amountLeft > 0)
        {
            InventorySlot slot = inventory.IsEmptySlotLeft(newItem, this);
            if (slot == null)
            {
                return;
            }
            else
            {
                slot.SetSlot(newItem, amountLeft);
            }
        }
    }

    public void ShowText()
    {
        if (item)
        {
            textMeshPro.text = item.itemName;
            textMeshPro.gameObject.SetActive(true);
        }
        else
        {
            textMeshPro.text = null;
            textMeshPro.gameObject.SetActive(false);
        }
    }
}
