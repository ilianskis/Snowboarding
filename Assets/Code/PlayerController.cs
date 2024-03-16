using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torquePower;
    [SerializeField] private float boostSpeed;
    [SerializeField] private float baseSpeed;
    
    
    private Rigidbody2D _rb;
    private SurfaceEffector2D _se;
    private bool _canMove = true;
    void Start()
    {
         _rb = GetComponent<Rigidbody2D>();
         _se = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (_canMove)
        {
            PlayerRotation();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        _canMove = false;
    }
    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            _se.speed = boostSpeed;
        }
        else
        {
            _se.speed = baseSpeed;
        }
    }

    private void PlayerRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            _rb.AddTorque(torquePower);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            _rb.AddTorque(-torquePower);
        }
    }
}
