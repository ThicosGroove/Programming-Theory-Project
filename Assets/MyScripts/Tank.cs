using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Vehicles
{
    private ControlMovement inputs;

    public GameObject cannonBallPrefab;
    public GameObject tankCannon;

    [SerializeField] private int _health = 5;
    [SerializeField] private float _speed;

    float fireRate = 0.5f;

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

        fireRate -= Time.deltaTime;

        if (shoot > 0.1f && fireRate <= 0f)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject newCannonBall = Instantiate(cannonBallPrefab, tankCannon.transform.position, Quaternion.identity, tankCannon.transform);

        fireRate = 0.5f;
    }
}
