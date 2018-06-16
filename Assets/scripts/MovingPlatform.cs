﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 MoveBy;
    public float Speed = 0.5f;
    public float Timeout = 1f;

    private Vector3 _pointA;
    private Vector3 _pointB;
    private bool _goingToA;

    private float _timeToWait;

    private void Start()
    {
        _pointA = transform.position;
        _pointB = transform.position + MoveBy;
    }

    private void Update()
    {
        var myPos = transform.position;
        var target = _goingToA ? _pointA : _pointB;

        if (IsArrived(myPos, target))
        {
            _timeToWait = Timeout;
            _goingToA = !_goingToA;
        }
        else
        {
            if (_timeToWait > 0)
            {
                _timeToWait -= Time.deltaTime;
            }
            else
            {
                myPos = Vector3.MoveTowards(myPos, target, Speed);
            }
        }

        transform.position = myPos;
    }

    private bool IsArrived(Vector3 pos, Vector3 target)
    {
        pos.z = 0;
        target.z = 0;
        return Vector3.Distance(pos, target) < 0.02f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}