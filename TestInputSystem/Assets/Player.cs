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
        if (_rb.velocity.magnitude == 0)
        {
            _rb.AddForce(Vector3.up * _force, ForceMode.Impulse);
        }
        Debug.Log("Jump");
    }
}
