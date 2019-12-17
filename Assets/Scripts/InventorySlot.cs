using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    GameObject item;

    public void AddItem(GameObject newItem)
    {
        item = newItem;

        icon.sprite = GetComponent<sc_obj>().sprite;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
