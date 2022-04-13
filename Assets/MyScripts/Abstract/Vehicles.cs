using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicles : MonoBehaviour
{
    protected float Speed { get; set; }
    protected int Health { get; set; }

    private float turnSpeed = 70f;

    protected virtual void Move(float move)
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        transform.Rotate(Vector3.up, move * turnSpeed * Time.deltaTime);
    }

    protected virtual void LostHealt()
    {
        Health--;
    }
}
