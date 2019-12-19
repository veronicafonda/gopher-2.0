using UnityEngine;
using UnityEngine.UI;

public class InventorySlot3 : MonoBehaviour
{
    public Image icon;


    GameObject item;

    public int counter;

    private void Start()
    {

    }

    public void AddItem(GameObject newItem)
    {
        //Debug.Log("SLOTS ADDITEM");
        item = newItem;

        int a = FindObjectOfType<sc_lv3_manager>().get_part();

        icon.color = new Color(1f, 1f, 1f, 1f);
        icon.sprite = item.GetComponent<sc_obj3>().sprite[a];

    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
