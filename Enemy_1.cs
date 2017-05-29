using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_1 : MonoBehaviour {

	public float targetDistance;
	public float enemyLookDistance;
	public float attackDistance;
	public float enemyMovementSpeed;
	public float damping;
	public Transform target;
	Rigidbody theRigidBody;
	Renderer myRender;

	// Use this for initialization
	void Start () {
		myRender = GetComponent<Renderer> ();
		theRigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		targetDistance = Vector3.Distance (target.position, transform.position);
		if(targetDistance<enemyLookDistance){
			myRender.material.color = Color.yellow;
			lookAtPlayer();
			print ("lookAtPlayer");
		}
		if (targetDistance < attackDistance) {
			myRender.material.color = Color.red;
			attackPlayer ();
			print ("ATTACK !");
		} 
		else {
			myRender.material.color = Color.blue;
		}
	}

	void lookAtPlayer(){
		Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
	}
	void attackPlayer(){
		theRigidBody.AddForce (transform.forward * enemyMovementSpeed);
	}
}
