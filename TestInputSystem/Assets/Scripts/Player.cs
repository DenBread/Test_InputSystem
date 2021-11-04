using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody _rb;
    [SerializeField] private float _force;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        playerController = new PlayerController();
        playerController.Player.Jump.performed += context => Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnEnable()
    {
        playerController.Enable();
    }

    private void OnDisable()
    {
        playerController.Disable();
    }

    private void Jump()
    {
        if (_rb.velocity.y == 0)
        {
            _rb.AddForce(Vector3.up * _force, ForceMode.Impulse);
            Debug.Log("Jump");
        }
    }

    private void Move()
    {
        Debug.Log(playerController.Player.AWSD.ReadValue<Vector2>());
        Vector2 vec = playerController.Player.AWSD.ReadValue<Vector2>();
        float speed = 5f;
        _rb.AddForce(new Vector3(vec.x, 0f, vec.y) * speed, ForceMode.Force);
    }
}
