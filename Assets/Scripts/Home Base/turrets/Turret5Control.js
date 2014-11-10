var LookAtTarget:Transform;
var savedtime;
var bulletPreFab:Transform;

function Start () {

}

function Update () {
	if(GameObject.Find("vehicle_playerShip").transform.position.z <= 0)
	{
		transform.LookAt(LookAtTarget);
	
		var seconds : int = Time.time;
		var oddeven = (seconds % 2);
		
		if(oddeven)
			shoot(seconds);
		
	}
}

function shoot(seconds){

	if(seconds != savedtime)
	{
		var bullet = Instantiate(bulletPreFab, transform.Find("spawnpoint").transform.position, Quaternion.identity);
		
		bullet.rigidbody.AddForce(transform.forward*2000);
		
		savedtime = seconds;
	}
}