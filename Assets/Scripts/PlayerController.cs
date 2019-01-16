using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 40f;
    public float turnSpeed = 10000f;
    public float acceleration = 10f;
    public float friction = 10f;
    public float rotationSmoothtime = 5f;
    public float health = 1f;
    public Transform body;
    Vector3 moveVector;
    Vector3 velocity;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    void Start()
    {
        velocity = Vector3.zero;
    }

    void Update()
    {
        Move();
        RotateBody();

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Fire();
        }
    }

    void Move()
    {
        Vector3 moveX = Vector3.right * Input.GetAxis("Horizontal");
        Vector3 moveZ = Vector3.forward * Input.GetAxis("Vertical");
        moveVector = moveX + moveZ;
        velocity += moveVector * acceleration * Time.deltaTime;
        transform.position += velocity * speed * Time.deltaTime;
        velocity -= friction * Time.deltaTime * velocity;
    }

    void RotateBody()
    {
        float xRot = Input.GetAxis("Horizontal2");
        if (Mathf.Abs(xRot) > 0.001f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.right * xRot, Vector3.up), Time.deltaTime * rotationSmoothtime);
        }
    }

    void Fire()
    {
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        Destroy(bullet, 1.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            health -= 1;

            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}