using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicles : MonoBehaviour
{
    public GameManager gameManager;

    protected float Speed { get; set; }
    protected int Health { get; set; }

    private float turnSpeed = 70f;

    protected virtual void Move(float move)
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        transform.Rotate(Vector3.up, move * turnSpeed * Time.deltaTime);
    }

    protected virtual void RoadLimits()
    {
        float xMin = -6.85f;
        float xMax = 6.85f;
        Vector3 currentPos = transform.position;

        if (transform.position.x < xMin) { transform.position = new Vector3(xMin, currentPos.y, currentPos.z);  }
        if (transform.position.x > xMax) { transform.position = new Vector3(xMax, currentPos.y, currentPos.z);  }
    }

    protected virtual void LostHealt()
    {
        Health--;
    }

    protected virtual void Die()
    {
        if (Health <= 0)
        {
            Speed = 0;

            //Open Canvas
            gameManager.GameOver();
        }
    }

}
