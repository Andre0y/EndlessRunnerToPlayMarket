using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    private float _minXposition = -5f;
    private float _maxXposition = 5f;
    private float _speed = 5f;
    private bool _left = true;
    private bool _right = false;

    private void Update()
    {
        if (_left)
        {
            transform.Translate(_speed * Time.deltaTime, 0f, 0f);
            if (transform.position.x >= _maxXposition)
            {
                _left = false;
                _right = true;
            }
        }

        if (_right)
        {
            transform.Translate(-_speed * Time.deltaTime, 0f, 0f);
            if (transform.position.x <= _minXposition)
            {
                _right = false;
                _left = true;
            }
        }
    }
}




    
    
    

