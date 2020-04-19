﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;
    float walkSpeed = 10f;
    Vector3 walkVec;
    Vector3 mouseDownPos;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {

    }

    void FixedUpdate()
    {
        Controller();
        SetVelocityFromWalkVec();
    }

    void Controller()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownPos = Input.mousePosition;
            animator.SetTrigger("Run");
        }

        if (Input.GetMouseButton(0))
        {
            SetWalkVec();
        }
    }


    void SetWalkVec()
    {

        Vector2 mouseVec = Input.mousePosition - mouseDownPos;

        //タップで止まる対策
        if (mouseVec.sqrMagnitude < 1.0f) { return; }
        walkVec.x = mouseVec.x;
        walkVec.z = mouseVec.y;

    }

    void SetVelocityFromWalkVec()
    {
        float degree = Vector2ToDegree(new Vector2(walkVec.z, walkVec.x));
        transform.eulerAngles = new Vector3(0, degree, 0);
        Vector3 vel = walkVec.normalized * walkSpeed;
        //落下しなくなるため、上に飛ばないようにする
        if (rb.velocity.y < 0) vel.y = rb.velocity.y;
        rb.velocity = vel;
    }

    float Vector2ToDegree(Vector2 vec)
    {
        return Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
    }
}