using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CombatScript : MonoBehaviour
{
    public int Damage;
    public float Range;
    public float rate = 1f;
    //public float armor;

    public new Transform transform;

    private float nextTimeToAttack = 0f;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToAttack)
        {
            nextTimeToAttack = Time.time + 1f/rate;
            Attack();
            
        }

     /*   if (Input.GetKeyDown(KeyCode.Mouse1))
        {

            Block();
        }*/

    }

  /*  void Block()
    {
        Target target = GetComponent<Target>();
        if (target != null)
        {
            target.TakeDamage(Damage - armor);
        }
        
    }*/

    public void Attack()
    {
        RaycastHit hit;
       if (Physics.Raycast(transform.position, transform.forward, out hit, Range)) 
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(Damage);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.forward);
    }


}
