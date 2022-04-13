using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Vehicles
{
    private MeshCollider m_Collider;
    private ControlMovement inputs;

    [SerializeField] private int _health = 1;
    [SerializeField] private float _speed;

    Vector3 _jumpVelocity;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _gravityValue;

    [SerializeField] private LayerMask layerMaskGround;

    private void Awake()
    {
        inputs = new ControlMovement();
        m_Collider = GetComponent<MeshCollider>();
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
        Speed = _speed;
        Health = _health;
    }

    void FixedUpdate()
    {
        Vector3 move = inputs.Car.Moving.ReadValue<Vector3>();
        float jump = inputs.Car.Jump.ReadValue<float>();

        Move();

        CheckGrounded();

        if (jump > 0.1f)
        {
            Debug.Log("JUMPOU");
            Jump();
        }
    }

    //protected override void Move()
    //{
    //    transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    //}

    void Jump()
    {
        if (CheckGrounded())
        {
            _jumpVelocity.y += Mathf.Sqrt(_jumpHeight * _gravityValue);

            //transform.Translate(Vector3.up * _jumpHeight * Time.deltaTime);

            //
        }
    }



    //NAO TA FUNCIONANDO
    bool CheckGrounded()
    {
        RaycastHit m_Hit;
        float extraHeight = 1.5f;
        bool isGrounded;

        isGrounded = Physics.BoxCast(m_Collider.bounds.center, Vector3.down, Vector3.down, out m_Hit, transform.rotation, extraHeight, layerMaskGround);

        if (isGrounded) {

            Debug.Log(m_Hit.collider.name);

            return true; }

        return false;
    }
}
