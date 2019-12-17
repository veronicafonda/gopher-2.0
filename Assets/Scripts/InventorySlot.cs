    using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Image icon2;


    GameObject item;

    public int counter;

    private void Start()
    {
        
    }

    public void AddItem(GameObject newItem)
    {
        Debug.Log("SLOTS ADDITEM");
        item = newItem;

        icon.sprite = item.GetComponent<sc_obj>().sprite;
        Debug.Log(icon.sprite.name);
        //icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
