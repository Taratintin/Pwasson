using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//Tutoriel : https://www.youtube.com/watch?v=lkDGk3TjsIE

	public float moveSpeed;
	private Rigidbody myRigidbody;

	private Vector3 moveInput;
	private Vector3 moveVelocity;	

	public GunController theGun;

	void Start () 
	{
		myRigidbody = GetComponent<Rigidbody> ();
	}
	

	void Update () 
	{
		moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0f, Input.GetAxisRaw ("Vertical"));
		moveVelocity = moveInput * moveSpeed;

		Vector3 aimInput = Vector3.right * Input.GetAxisRaw ("Right_Horizontal") + Vector3.forward * -Input.GetAxisRaw ("Right_Vertical");

		if (aimInput.sqrMagnitude > 0.0f)
		{
			transform.rotation = Quaternion.LookRotation (aimInput, Vector3.up);
		}

		if (Input.GetAxisRaw("Right_Trigger") == 1)
		{
			theGun.isFiring = true;
		}

		else 
		{
			theGun.isFiring = false;
		}

		if (Input.GetButtonDown("Right_Bumper"))
		{
			switch (theGun.state)
			{
			case GunController.GunType.AK47:
				theGun.state = GunController.GunType.Shotgun;
				break;
			case GunController.GunType.Shotgun:
				theGun.state = GunController.GunType.AK47;
				break;
			}
		}

		if (Input.GetButtonDown("Left_Bumper"))
		{
			switch (theGun.state)
			{
			case GunController.GunType.AK47:
				theGun.state = GunController.GunType.Shotgun;
				break;
			case GunController.GunType.Shotgun:
				theGun.state = GunController.GunType.AK47;
				break;
			}
		}
	}

	void FixedUpdate ()
	{
		myRigidbody.velocity = moveVelocity;
	}
}
