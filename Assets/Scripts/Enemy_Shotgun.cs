using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Shotgun : MonoBehaviour {

	public float targetDistance;
	public float enemyLookDistance;
	public float attackDistance;
	public float enemyMovementSpeed;
	public float damping;
	public float shootDistance;
	public Transform target;
	Renderer myRender;
	private NavMeshAgent navMesh;
	public GunController theGun;


	// Use this for initialization
	void Start () {
		myRender = GetComponent<Renderer> ();
		navMesh = GetComponent<NavMeshAgent> ();
		theGun.state = GunController.GunType.Shotgun;
	}

	// Update is called once per frame
	void Update () {

		targetDistance = Vector3.Distance (target.position, transform.position);

		if (targetDistance<=enemyLookDistance) {
			myRender.material.color = Color.red;
			lookAtPlayer ();
			moveToPlayer ();
			print ("ATTACK !");
		} 
		if (targetDistance <= shootDistance) {
			theGun.isFiring = true;
			print ("shooting the bastard");
		}
		else {
			theGun.isFiring = false;
		}
	}

	void lookAtPlayer(){
		Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
	}
	void moveToPlayer(){
		navMesh.SetDestination(target.position);
	}

}