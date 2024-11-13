using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Inventory")]
    public SO_Item EMPTY_ITEM;
    public Transform slotPrefab;
    public Transform inventoryPanel;
    protected GridLayoutGroup gridLayoutGroup;
    [Space(5)]
    public int slotAmount = 1;
    public InventorySlot[] inventorySlots;

    void Start()
    {
        gridLayoutGroup = inventoryPanel.GetComponent<GridLayoutGroup>();
        CreateInventorySlots();
    }

    #region Inventory Methods
    public void CreateInventorySlots()
    {
        inventorySlots = new InventorySlot[slotAmount];
        for (int i = 0; i < slotAmount; i++)
        {
            Transform slot = Instantiate(slotPrefab, inventoryPanel);
            InventorySlot invSlot = slot.GetComponent<InventorySlot>();

            inventorySlots[i] = invSlot;
            invSlot.inventory = this;
            invSlot.SetSlot(EMPTY_ITEM, 0);
        }
    }

    public InventorySlot IsEmptySlotLeft(SO_Item newItam = null, InventorySlot invSlot = null)
    {
        InventorySlot emptySlot = null;
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot == invSlot)
            {
                continue;
            } else if (slot.item == newItam && slot.stack == slot.item.maxStack)
            {
                return slot;
            } else if (slot.item == EMPTY_ITEM && emptySlot == null)
            {
                emptySlot = slot;
            }
        }
        return emptySlot;
    }

    #endregion
}
