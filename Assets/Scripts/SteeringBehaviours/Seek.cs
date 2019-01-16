using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehaviour
{
    Vector3 desired;
    Vector3 steeringForce;

    Transform target;

    public override void Steer()
    {
        desired = target.position - transform.position;
        desired = desired.normalized * maxSpeed;
        steeringForce = desired - vehicle.Velocity;
        steeringForce = Vector3.ClampMagnitude(steeringForce, maxForce);
        vehicle.ApplyForce(steeringForce);
    }

    public override void Awake()
    {
        base.Awake();
        target = GameObject.Find("character").transform;
    }
}