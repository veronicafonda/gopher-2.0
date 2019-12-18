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
        //Debug.Log("SLOTS ADDITEM");
        item = newItem;

        
        //Debug.Log(icon.sprite.name);
        //icon.enabled = true;

        if(sc_hero.levelProgress == 9)
        {
            icon2.color = new Color(1f, 1f, 1f, 1f);
            icon2.sprite = item.GetComponent<sc_obj>().sprite;
        }
        else
        {
            icon.color = new Color(1f, 1f, 1f, 1f);
            icon.sprite = item.GetComponent<sc_obj>().sprite;
        }
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
