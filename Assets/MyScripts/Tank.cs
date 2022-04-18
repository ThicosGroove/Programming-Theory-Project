using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Vehicles
{
    private ControlMovement inputs;

    [Header("All Vehicles")]
    [SerializeField] private int _health = 5;
    [SerializeField] private float _speed;

    [Header("Tank Hability Shoot")]
    public GameObject cannonBallPrefab;
    public GameObject tankCannon;
    float fireRate = 0.5f;
    public Transform parentTransform = null;

    private void Awake()
    {
        inputs = new ControlMovement();
    }

    void OnEnable()
    {
        inputs.Enable();
    }

    void OnDisable()
    {
        inputs.Disable();
    }

    void Start()
    {
        Health = _health;
        Speed = _speed;
    }

    void Update()
    {
        float move = inputs.Car.Moving.ReadValue<float>();
        float shoot = inputs.Tank.Shoot.ReadValue<float>();

        Move(move);
        RoadLimits();

        fireRate -= Time.deltaTime;

        if (shoot > 0.1f && fireRate <= 0f)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject newCannonBall = Instantiate(cannonBallPrefab, tankCannon.transform.position, Quaternion.identity, parentTransform);

        fireRate = 0.5f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            LostHealt();
            Die();
        }
    }
}
