using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Path : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoints;
    EnemyController _chase;
    public void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i= 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    public void Update()
    {

        Transform target = _points[_currentPoints];

        transform.position =  Vector3.MoveTowards(transform.position, target.position, 3 * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoints++;
            if (_currentPoints >= _points.Length)
            {
                _currentPoints = 0;
            }
        }  
       

    }

    
}
