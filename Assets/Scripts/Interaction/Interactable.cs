using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string id;
    public abstract void Interact();

    public virtual void VirtualFunction()
    {
        //Debug.Log("This is a Virtual Function.");
    }
}
