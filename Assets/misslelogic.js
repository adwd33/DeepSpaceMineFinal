﻿#pragma strict

function Start () {

}

function Update () {

}

function OnTriggerEnter (other : Collider) {
//only destroys the enemys
		if(other.tag == "enemy"){
			Destroy(other.gameObject);
			Destroy (gameObject);
			globalMethod.enemys -= 1;
		}
}