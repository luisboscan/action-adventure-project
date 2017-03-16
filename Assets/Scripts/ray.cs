using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray : MonoBehaviour {
	public Transform player;
	public AI enemy;
	private RaycastHit hit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		transform.LookAt (player);
		Physics.Raycast (transform.position, fwd, out hit, 30);
		if (hit.collider.gameObject.tag == "Player"){
			enemy.chase = true;
		}else{
			enemy.chase = false;
		}

	}
}
