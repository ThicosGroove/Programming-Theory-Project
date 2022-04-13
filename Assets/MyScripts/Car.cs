using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Vehicles
{
    private ControlMovement inputs;
    private Rigidbody rb;

    [Header("All Vehicles")]
    [SerializeField] private int _health = 1;
    [SerializeField] private float _speed;

    [Header("Car Hability Jump")]
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float fallMultiplier = 3.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    private float jumpInput;

    [Header("Collision")]
    private MeshCollider m_Collider;
    [SerializeField] private LayerMask layerMaskGround;

    private void Awake()
    {
        inputs = new ControlMovement();
        m_Collider = GetComponent<MeshCollider>();
        rb = GetComponent<Rigidbody>();
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
        float move = inputs.Car.Moving.ReadValue<float>();
        jumpInput = inputs.Car.Jump.ReadValue<float>();

        Move(move);
        GroundedCheck();
        BetterJump();

        if (jumpInput > 0.1f)
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (GroundedCheck())
        {
            rb.velocity = Vector3.up * _jumpHeight; 
        }
    }

    private void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && jumpInput == 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private bool GroundedCheck()
    {
        float extraHeight = 0.5f;

        bool raycastHit = Physics.Raycast(m_Collider.bounds.center, Vector3.down, m_Collider.bounds.extents.y + extraHeight, layerMaskGround);

        if (raycastHit) { return true; }

        return false;
    }   
}
