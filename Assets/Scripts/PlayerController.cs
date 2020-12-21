using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private CharacterController _characterController;
	public float MovementSpeed = 5.0f;
	public float Gravity = -9.81f;
	
	private void Awake()
	{
		_characterController = GetComponent<CharacterController>();
	}

	private void Update()
	{
		Vector3 movementZ = Input.GetAxisRaw("Vertical") * Vector3.forward * Time.deltaTime * MovementSpeed;
		Vector3 movementX = Input.GetAxisRaw("Horizontal") * Vector3.right * Time.deltaTime * MovementSpeed;
		
		Vector3 movement = transform.TransformDirection(movementX + movementZ);  
		movement.y = Gravity * Time.deltaTime;

		_characterController.Move(movement);
	}
}
