using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
	public Transform player;
	public bool chase;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (chase == true){
		transform.LookAt (player);
		transform.Translate (0, 0, 0.1f);
	}
}
}