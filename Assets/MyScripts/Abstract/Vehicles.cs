using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicles : MonoBehaviour
{
    protected float Speed { get; set; }
    protected int Health { get; set; }

    protected virtual void Move()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    protected virtual void LostHealt()
    {
        Health--;
    }
}
