using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected abstract void ItemGet();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ItemGet();
        }
    }
}
