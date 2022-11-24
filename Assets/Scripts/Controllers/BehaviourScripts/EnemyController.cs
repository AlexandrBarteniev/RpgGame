using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using Unity.VisualScripting;

public class EnemyController : MonoBehaviour
{

    public float _speed;
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    CombatScript startFight;
    Animator animator;
    Path patrol;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        _speed = agent.speed;
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            _speed = 4;
            animator.SetFloat("ChaseSpeed", _speed, 0, Time.deltaTime);
            agent.SetDestination(target.position);
            Track();

            if (distance <= agent.stoppingDistance)
            {
                _speed = 0;
                // startFight.Attack();
                animator.SetBool("Attack", true);
            }
            else if (distance > agent.stoppingDistance)
            {
                _speed = agent.speed;
                animator.SetBool("Attack", false);
                animator.SetFloat("ChaseSpeed", _speed, 0, Time.deltaTime);
            }



        } 
        else if (distance > lookRadius)
        {
            _speed = 0;
            animator.SetFloat("ChaseSpeed", _speed, 0, Time.deltaTime);

        }


    }

    void Track()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }


}