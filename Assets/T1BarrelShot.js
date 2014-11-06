var bulletPreFab:Transform;
var savedtime;

function Start () {

}

function Update () {

	var seconds : int = Time.time;
	var oddeven = (seconds % 2);
	
	if(oddeven)
		shoot(seconds);
}

function shoot(seconds){

	if(seconds != savedtime)
	{
		var bullet = Instantiate(bulletPreFab, GameObject.Find("spawnpoint").transform.position, Quaternion.identity);
		
		bullet.rigidbody.AddForce(transform.forward*20);
		
		savedtime = seconds;
	}
}