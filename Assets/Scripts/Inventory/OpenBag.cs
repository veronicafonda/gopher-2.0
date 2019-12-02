using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenBag: MonoBehaviour
{
    public Button bagButton;
    public Image bagContent;
    public Image item1;
    public Image item2;

    // Start is called before the first frame update
    void Start()
    {
        bagContent.enabled = false;
        item1.enabled = false;
        item2.enabled = false;
        bagButton.onClick.AddListener(ButtonClicked);
    }

    void ButtonClicked()
    {
        bagContent.enabled = !bagContent.enabled;
        item1.enabled = !item1.enabled;
        item2.enabled = !item2.enabled;
    }
}
