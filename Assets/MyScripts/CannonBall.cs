using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] private float cannonForceZ = 30f;
    [SerializeField] private float cannonForceY = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.AddForce(new Vector3(0, cannonForceY, cannonForceZ), ForceMode.Impulse);
    }
}
