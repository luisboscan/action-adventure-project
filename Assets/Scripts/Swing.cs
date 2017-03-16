using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour {

	//get script from player for attack
	public Move plr;


	//trigger, enemies in it will take damage
	void OnTriggerEnter(Collider other){
		Debug.Log ("Hit");
		//get enemy script
		Enemy en = other.gameObject.GetComponent<Enemy> ();
		//check if player is weilding fire and if enemy is susceptible to fire
		if (plr.fire == true && en.fire == true){
			en.health -= plr.dmg;
	}
		//check if player is weilding ice and if enemy is susceptible to ice
		if (plr.ice == true && en.ice == true) {
			en.health -= plr.dmg;
		}
}
}