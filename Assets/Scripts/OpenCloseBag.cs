using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseBag : MonoBehaviour
{
    public Button bagButton;
    public Image bagContent;
    // Start is called before the first frame update
    void Start()
    {
        bagContent.enabled = false;
        bagButton.onClick.AddListener(InventoryController);
    }
    
    void InventoryController()
    {
        bagContent.enabled = !bagContent.enabled;
    }
}
