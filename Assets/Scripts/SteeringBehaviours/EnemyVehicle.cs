using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVehicle : MonoBehaviour
{
    public Vector3 Velocity { get; set; }

    public SteeringBehaviour[] steeringBehaviours;

    void Awake()
    {
        steeringBehaviours = GetComponents<SteeringBehaviour>();
    }
    public void ApplyForce(Vector3 force)
    {
        Velocity += force;
    }

    public void UpdateVehicle()
    {
        transform.position += Velocity * Time.deltaTime;
    }
}
