using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Interactable
{
    public override void Interact()
    {
        transform.position += transform.forward * 0.1f;
        Debug.Log("Cube interacted");
    }

    public override void VirtualFunction()
    {
        //Debug.Log("This is the cube's own definition");
        //base.VirtualFunction();
    }
}
