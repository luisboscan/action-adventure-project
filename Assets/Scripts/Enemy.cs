using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	//bools (is enemy fire, ice, or both)
	public bool fire = true;
	public bool ice = false;
	//floats
	public float health;
	// Use this for initialization

	//death enum
	IEnumerator Dead(){
		yield return null;
		Debug.Log ("Enemy Dead");
		Destroy (gameObject);
	}

	void Start () {
		//give enemy health
		health = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		//calculate enemy current health
		if (health <= 0)
			StartCoroutine (Dead ());
	}

}
