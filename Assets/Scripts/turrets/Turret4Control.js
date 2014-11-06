var LookAtTarget:Transform;
var savedtime;

function Start () {

}

function Update () {
	if(GameObject.Find("vehicle_playerShip").transform.position.x <= 0)
		transform.LookAt(LookAtTarget);
	
}