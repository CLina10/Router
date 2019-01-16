using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringBehaviour : MonoBehaviour
{
    protected EnemyVehicle vehicle;
    [SerializeField]
    protected float maxSpeed = 4f;
    [SerializeField]
    protected float maxForce = 1f;
    public abstract void Steer();

    public virtual void Awake()
    {
        vehicle = GetComponent<EnemyVehicle>();
    }
}
