using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    Inventory inventory;

    InventorySlot slots;

    #region code gw
    /*public Image Slot;

    public GameObject keranjang;
    public GameObject baju1;
    public GameObject baju2;
    public GameObject baju3;

    public Sprite baju1Sprite;
    public Sprite baju2Sprite;
    public Sprite baju3Sprite;*/
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponent<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI()
    {
        Debug.Log("Update UI + ");

        slots.AddItem(inventory.items[inventory.items.Count-1]); 
    }
}