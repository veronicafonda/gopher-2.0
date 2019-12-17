using UnityEngine;
using UnityEngine.UI;

public class InventoryUI2 : MonoBehaviour
{
    Inventory inventory;
    public Image Slot;

    public GameObject konci;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        Slot = GetComponent<Image>();
        var tempColor = Slot.color;
        tempColor.a = 0f;
        Slot.color = tempColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (konci.activeSelf == false)
        {
            Slot = GetComponent<Image>();
            var tempColor = Slot.color;
            tempColor.a = 1f;
            Slot.color = tempColor;
        }
    }

    void UpdateUI()
    {
        Debug.Log("Update UI");
    }
}