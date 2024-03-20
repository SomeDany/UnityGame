using PHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaterFloat))]
public class Control : MonoBehaviour
{
    //visible Properties
    public Transform Pvrt;
    public float SteerPower = 500f;
    public float Power = 5f;
    public float MaxSpeed = 10f;
    public float Drag = 0.1f;

    //used Components
    protected Rigidbody Rigidbody;
    protected Quaternion StartRotation;



    public void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        StartRotation = Pvrt.localRotation;
    }

    public void FixedUpdate()
    {
        //default direction
        var forceDirection = transform.forward;
        var steer = 0;

        //steer direction [-1,0,1]
        if (Input.GetKey(KeyCode.A))
            steer = 1;
        if (Input.GetKey(KeyCode.D))
            steer = -1;


        //Rotational Force
        Rigidbody.AddForceAtPosition(steer * transform.right * SteerPower / 100f, Pvrt.position);

        //compute vectors
        var forward = Vector3.Scale(new Vector3(1,0,1), transform.forward);
        var targetVel = Vector3.zero;

        //forward/backward poewr
        if (Input.GetKey(KeyCode.W))
        {
            PhysicsHelper.ApplyForceToReachVelocity(Rigidbody, forward * MaxSpeed, Power);
        }
            
        //Motor Animation // Particle system
        Pvrt.SetPositionAndRotation(Pvrt.position, transform.rotation * StartRotation * Quaternion.Euler(0, 30f * steer, 0));
       

        //moving forward
        var movingForward = Vector3.Cross(transform.forward, Rigidbody.velocity).y < 0;

        //move in direction
        Rigidbody.velocity = Quaternion.AngleAxis(Vector3.SignedAngle(Rigidbody.velocity, (movingForward ? 1f : 0f) * transform.forward, Vector3.up) * Drag, Vector3.up) * Rigidbody.velocity;
    }

}