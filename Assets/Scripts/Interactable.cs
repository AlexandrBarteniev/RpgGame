using UnityEngine;
using UnityEngine.AI;



/*[RequireComponent(typeof(ColorOnHover))]*/
public class Interactable : MonoBehaviour
{

    public float radius = 3f;
    public Transform interactionTransform;
    public Transform player;
    InventorySlot slot;// Reference to the player transform

    bool hasInteracted = false; // Have we already interacted with the object?

    void Update()
    { 

        if (Input.GetKey(KeyCode.E))   
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
         
            if (!hasInteracted && distance <= radius)
            {
                
                hasInteracted = true;
                Interact();
            }
        }
    }

    
    public virtual void Interact()
    {

    }

    void OnDrawGizmosSelected()
    {
        if(interactionTransform == null )
            interactionTransform = transform;


        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

    

}