using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public ParticleSystem particle;
    public Transform cannon;

    Rigidbody rb;

    [SerializeField] private float cannonForceZ = 30f;
    [SerializeField] private float cannonForceY = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.AddForce(new Vector3(0f, cannonForceY, cannonForceZ), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) { return; }
        if (collision.gameObject.CompareTag("CannonBall")) { return; }

        particle.Play();

        Destroy(this.gameObject, 2f);
    }
}
