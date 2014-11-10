var LookAtTarget:Transform;
var savedtime;
var bulletPreFab:Transform;
var misslePreFab:Transform;
var bombPreFab:Transform;
var bomb:int;
var missle:int;
var turret:int;

function Start () {

	bomb = 0;
	missle = 0;
	turret = 1;
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
	if (Input.GetButtonDown("Fire2"))
	{
		bomb = 1;
		turret = 0;
		missle = 0;
	}
	if (Input.GetButtonDown("Fire3"))
	{
		bomb = 0;
		turret = 0;
		missle = 1;
	}
		if (Input.GetButtonDown("Fire4"))
	{
		bomb = 0;
		turret = 1;
		missle = 0;
	}
}

function shoot(seconds){

	if(turret == 1)
	{
		if(seconds != savedtime)
		{
			var bullet = Instantiate(bulletPreFab, transform.Find("spawnpoint").transform.position, Quaternion.identity);
			
			bullet.rigidbody.AddForce(transform.forward*2000);
			
			savedtime = seconds;
		}
	}
	else if(missle == 1)
	{
		var missle = Instantiate(misslePreFab, transform.Find("spawnpoint").transform.position, Quaternion.identity);
			
		missle.rigidbody.AddForce(transform.forward*200);
	}
	else
	{
	
	}
}