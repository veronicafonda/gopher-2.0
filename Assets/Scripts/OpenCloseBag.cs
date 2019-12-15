using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseBag : MonoBehaviour
{
    public Button bagButton;
    public Image bagContent;
    public Image Item1;
    public Image Item2;

    // Start is called before the first frame update
    void Start()
    {
        bagContent.enabled = false;
        Item1.enabled = false;
        Item2.enabled = false;
        bagButton.onClick.AddListener(InventoryController);
    }
    
    void InventoryController()
    {
        bagContent.enabled = !bagContent.enabled;
        Item1.enabled = !Item1.enabled;
        Item2.enabled = !Item2.enabled;
    }
}
