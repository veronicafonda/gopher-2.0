using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton    

    public static Inventory instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("instance already exist ");
            return;
        }
        instance = this;
    }

    #endregion

    public int space = 20;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<GameObject> items = new List<GameObject>();


    public bool Add(GameObject item)
    {
        Debug.Log("masukn ke inventory.additem");
        if (items.Count >= space)
        {
            Debug.Log("Not enough room");
            return false;
        }

        items.Add(item);
        

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        return true;

    }
}
