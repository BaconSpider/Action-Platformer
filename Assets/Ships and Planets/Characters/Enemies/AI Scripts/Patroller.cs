﻿using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] Transform leftPoint;
    [SerializeField] Transform rightPoint;
    [SerializeField] float speed = 5f;

    float positionSphereRadius = .2f;
    Rigidbody2D rigidBody;
    bool movingRight = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(movingRight && transform.position.x >= rightPoint.position.x)
        {
            movingRight = false;
        }
        else if(!movingRight && transform.position.x <= leftPoint.position.x)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
        }
        else
        {
            rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
        }
    }

    void OnDrawGizmos()
    {
        // Sphere around start of patrol route
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(leftPoint.position, positionSphereRadius);

        // Sphere around end of patrol route
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(rightPoint.position, positionSphereRadius);

        // Connecter line for the two spheres
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(leftPoint.position, rightPoint.position);
    }
}
