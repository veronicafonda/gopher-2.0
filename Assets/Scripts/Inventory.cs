using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public List<GameObject> items = new List<GameObject>();


    public void Add(GameObject item)
    {
        items.Add(item);
    }
}
