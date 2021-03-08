using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
    public float mass = 1f;
    public Vector3 velocityVector = Vector3.zero; //Avg. velocity this FixedUpdate()
    public Vector3 netForceVector = Vector3.zero;
    public List<Vector3> forceVectorList = new List<Vector3>();

    private void FixedUpdate()
    {
        AddForce();

        UpdateVelocity();

        UpdatePosition();
    }

    private void AddForce()
    {
        netForceVector = Vector3.zero;

        foreach (Vector3 _forceVector in forceVectorList)
        {
            netForceVector += _forceVector;
        }
    }

    private void UpdateVelocity()
    {
        Vector3 _accelerationVector = netForceVector / mass;

        velocityVector += _accelerationVector * Time.deltaTime;
    }

    private void UpdatePosition()
    {
        Vector3 _deltaS = velocityVector * Time.deltaTime;

        transform.position += _deltaS;
    }
}
