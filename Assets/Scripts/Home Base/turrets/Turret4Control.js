﻿var LookAtTarget:Transform;
var savedtime;
var bulletPreFab:Transform;
var misslePreFab:Transform;
var bombPreFab:Transform;

static var type4:int;
static var level4:int;

var bombtime = 0;

function Start () {
	type4 = 1;
}


function Update () {
	if(GameObject.Find("vehicle_playerShip").transform.position.x <= 0)
	{
		transform.LookAt(LookAtTarget);
	
		var seconds : int = Time.time;
		var oddeven;
		
		if(type4 == 3)
			oddeven = (seconds % 10);
		else 
			oddeven = (seconds % 2);
		
		if(oddeven)
			shoot(seconds);
		
	}
	bombtime++;
}

function shoot(seconds){

	if(type4 == 1)
	{
		if(seconds != savedtime)
		{
			var bullet = Instantiate(bulletPreFab, transform.Find("spawnpoint").transform.position, Quaternion.identity);
			
			bullet.rigidbody.AddForce(transform.forward*2000);
			
			savedtime = seconds;
		}
	}
	else if(type4 == 2)
	{
		var missle = Instantiate(misslePreFab, transform.Find("spawnpoint").transform.position, Quaternion.identity);
			
		missle.rigidbody.AddForce(transform.forward*200);
	}
	else
	{
		if(bombtime > 240)
		{
			if(seconds != savedtime)
			{
				
				var bomb = Instantiate(bombPreFab, transform.Find("spawnpoint").transform.position, Quaternion.identity);
				
				bomb.rigidbody.AddForce(transform.forward*1000);
				
				savedtime = seconds;
			}
			bombtime = 0;
		}
	}
}