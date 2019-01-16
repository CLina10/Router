using System.Collections.Generic;
using UnityEngine;

public class Seperation : SteeringBehaviour
{
    AI ai;
    [SerializeField]
    float seperationDistance = 2f;

    public override void Awake()
    {
        base.Awake();
        ai = FindObjectOfType<AI>();
        vehicle = GetComponent<EnemyVehicle>();
    }

    public override void Steer()
    {
        Vector3 avarageDir = Vector3.zero;
        int numberOfCloseVehicles = 0;

        for (int i = 0; i < ai.enemyVehicles.Count; i++)
        {
            Vector3 direction = transform.position - ai.enemyVehicles[i].transform.position;
            if ((direction.sqrMagnitude) < (seperationDistance * seperationDistance) && direction.sqrMagnitude > 0.00001f)
            {
                numberOfCloseVehicles++;
                avarageDir += direction.normalized;
            }
        }
        if (numberOfCloseVehicles > 0)
        {
            avarageDir = avarageDir / numberOfCloseVehicles;
        }
        else
        {
            return;
        }
        Vector3 desired = avarageDir * maxSpeed;
        Vector3 steeringForce = desired - vehicle.Velocity;
        steeringForce = Vector3.ClampMagnitude(steeringForce, maxForce);
        vehicle.ApplyForce(steeringForce);
    }
}