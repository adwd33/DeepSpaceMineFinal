#pragma strict

var LookAtTarget:Transform;
function Start () {

}

function Update () {
	transform.LookAt(LookAtTarget);
}