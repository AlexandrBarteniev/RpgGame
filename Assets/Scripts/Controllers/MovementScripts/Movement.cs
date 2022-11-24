using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    Camera _camera;
    const float locomationAnimationSmoothTime = 0.1f;


    Animator animator;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        #region Movement
        _speed = agent.speed;

        if (Input.GetKey(KeyCode.D))
        {
            _speed = 3;
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            animator.SetFloat("StrafeSpeed", _speed, 0, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _speed = 3;
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            animator.SetFloat("StrafeSpeed", -_speed, 0, Time.deltaTime);

        }
        else
        {
            animator.SetFloat("StrafeSpeed", _speed = 0, 0, Time.deltaTime);
        }



        if (Input.GetKey(KeyCode.W))
        {
            _speed = 4;
            transform.Translate(0, 0, _speed * Time.deltaTime);
            animator.SetFloat("Speed", _speed, locomationAnimationSmoothTime, Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            _speed = 3;
            transform.Translate(0, 0, _speed * Time.deltaTime * -1);
            animator.SetFloat("Speed", -_speed, locomationAnimationSmoothTime, Time.deltaTime);

        }


        else
        {
            animator.SetFloat("Speed", _speed = 0, locomationAnimationSmoothTime, Time.deltaTime);
        }
        if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.LeftShift)))
        {
            _speed = 6;
            transform.Translate(0, 0, _speed * Time.deltaTime);
            animator.SetFloat("Speed", _speed, locomationAnimationSmoothTime, Time.deltaTime);

        }

        #endregion

        #region Combat
        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack");
        }


        if (Input.GetKey(KeyCode.Mouse1))
        {
            animator.SetTrigger("Block");
        }
        #endregion

        /*if (Input.GetKey(KeyCode.E))
        {
            // Shoot out a ray
            Ray ray = _camera.ScreenPointToRay(Camera.main.transform.forward);
            RaycastHit hit;

            // If we hit
            if (Physics.Raycast(ray, out hit, 100f))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
            }
        }*/

    }
}
