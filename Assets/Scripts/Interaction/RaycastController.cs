using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastController : MonoBehaviour
{
    [SerializeField]
    private float raycastDistance = 5.0f;

    [SerializeField]
    //The layer that will determine what the raycast will hit
    LayerMask layerMask;
    //The UI text component that will display the name of the interactable hit
    public TextMeshProUGUI interactionInfo;

    // Update is called once per frame
    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,
            transform.forward, out hit, raycastDistance))
        {
            //Debug.Log($"Raycast has hit {hit.collider.gameObject.name}");
            /*
            // old way if Raycast hits an Interactable class, call Interact function
            if(hit.collider.gameObject.GetComponent<Interactable>() != null)
            {
                hit.collider.gameObject.GetComponent<Interactable>().Interact();
            }
            */
            // new way 
            if(hit.collider.TryGetComponent<Interactable>(out Interactable interactable))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    interactable.Interact();
                }
            }
        }
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.red);

        //TODO: Raycast
        //1. Perform a raycast originating from the gameobject's position towards its forward direction.
        //   Make sure that the raycast will only hit the layer specified in the layermask
        //2. Check if the object hits any Interactable. If it does, show the interactionInfo and set its text
        //   to the id of the Interactable hit. If it doesn't hit any Interactable, simply disable the text
        //3. Make sure to interact with the Interactable only when the mouse button is pressed.
    }
}