using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory_siblings : MonoBehaviour
{
    public int index;

    private void Start()
    {
        index = transform.GetSiblingIndex();
        transform.SetSiblingIndex(index);
    }
    public void raised()
    {
        index = 0;
        transform.SetSiblingIndex(index);
    }

    public void lower()
    {
        index = 1;
        transform.SetSiblingIndex(index);
    }

}
