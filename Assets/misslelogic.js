#pragma strict

function Start () {

}

function Update () {

}

//only destroys the enemys
		if(other.tag == "enemy"){
			Destroy(other.gameObject);
			Destroy (gameObject);
			globalMethod.enemys -= 1;
		}