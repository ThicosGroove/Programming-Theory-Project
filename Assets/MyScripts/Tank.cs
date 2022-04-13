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


    // Start is called before the first frame update
    void Start()
    {
        Health = _health;
        Speed = _speed;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 move = inputs.Car.Moving.ReadValue<Vector3>();
        float shoot = inputs.Car.Jump.ReadValue<float>();

        Move();

        if (shoot > 0.1f)
        {
            Shoot();
        }
    }

    //protected override void Move()
    //{
    //    transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    //}

    void Shoot()
    {

        float fireRate = 0.5f;

        fireRate -= Time.deltaTime;

        if (fireRate <= 0)
        {

            GameObject newCannonBall = Instantiate(cannonBallPrefab, tankCannon.transform.position, Quaternion.identity, transform);

            Debug.Log("SHOOTOUS");

            fireRate = 0.5f;
        }

        // instantiate Cannon Ball
        // from Cannon
    }
}
