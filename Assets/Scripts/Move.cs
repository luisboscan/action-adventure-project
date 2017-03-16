using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	//floats
	public float dash = 1;
	public float dashtmr = 0.5f;
	public float dmg = 1f;
	//bools
	public bool fire = true;
	public bool ice = false;
	//attack zone
	public GameObject attackzone;

	// Use this for initialization
	void Start () {
		//get player renderer and give fire color
		gameObject.GetComponent<Renderer> ().material.color = Color.red;
	}
	//enum for attack
	IEnumerator Attack(){
		attackzone.SetActive (true);
		yield return new WaitForSeconds (0.1f);
		attackzone.SetActive (false);
	}
	//enum for dash
	IEnumerator Dash(){
		dash = 20;
		yield return new WaitForSeconds (0.1f);
		dash = 1;
	}
		
	
	// Update is called once per frame
	void Update ()
	{
		//change between fire and ice on Q press
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (fire == true && ice == false) {
				gameObject.GetComponent<Renderer> ().material.color = Color.blue;
				fire = false;
				ice = true;
			} else {
				if (fire == false && ice == true) {
					gameObject.GetComponent<Renderer> ().material.color = Color.red;
					fire = true;
					ice = false;
				}
			}
		}
		//over simplified movement
			if (Input.GetKey (KeyCode.W)) {
				transform.Translate (Vector3.forward * dash * Time.deltaTime);
			} else {
				if (Input.GetKey (KeyCode.S)) {
					transform.Translate (Vector3.forward * dash * -Time.deltaTime);
				}
			}
			if (Input.GetKey (KeyCode.A)) {
				transform.Translate (Vector3.forward * dash * Time.deltaTime);
				transform.Rotate (Vector3.down * 100 * Time.deltaTime);
			} else {
				if (Input.GetKey (KeyCode.D)) {
					transform.Translate (Vector3.forward * dash * Time.deltaTime);
					transform.Rotate (Vector3.up * 100 * Time.deltaTime);
				}
			}
			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				StartCoroutine (Dash ());
			}

			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				StartCoroutine (Attack ());

			}
		}
	}


