using UnityEngine;
using UnityEngine.UI;

public class InventoryUI3 : MonoBehaviour
{
    public Transform itemsParent;

    Inventory inventory;

    InventorySlot3 slots;



    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponent<InventorySlot3>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI()
    {
        Debug.Log("Update UI + ");

        slots.AddItem(inventory.items[inventory.items.Count - 1]);
    }
}