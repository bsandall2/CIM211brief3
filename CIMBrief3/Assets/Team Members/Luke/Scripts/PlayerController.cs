using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel.Configuration;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	private PlayerControls _input;
	private InputAction _move;
	
	[SerializeField] private Vector2 moveInput;

	[SerializeField] private Rigidbody rb;
	[SerializeField] private Transform _transform;

	public float moveSpeed = 0.2f;
	
	private void OnEnable()
	{
		_move = _input.Player.Move;
		_move.Enable();
		_move.performed += MoveInput;
		_move.canceled += MoveInputCancel;
	}

	private void OnDisable()
	{
		_move.Disable();
		_move.performed -= MoveInput;
		_move.canceled -= MoveInputCancel;
	}

	void Awake()
	{
		_input = new PlayerControls();
	}

	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
	    rb.angularVelocity = Vector3.zero;
	    Move(moveInput);
    }

    private void MoveInput(InputAction.CallbackContext context)
    {
	    moveInput = context.ReadValue<Vector2>();
    }

    private void MoveInputCancel(InputAction.CallbackContext context)
    {
	    moveInput = Vector2.zero;
    }
    
    private void Move(Vector2 input)
    {
	    Vector3 position = _transform.position;
	    Vector3 heading = new Vector3(position.x + moveSpeed*input.x, position.y, position.z + moveSpeed*input.y);
	    rb.MovePosition(heading);
    }
}
