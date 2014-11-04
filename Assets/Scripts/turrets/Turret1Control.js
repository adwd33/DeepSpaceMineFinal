var LookAtTarget:Transform;
var bulletPreFab:Transform;
var savedtime;

function Start () {

}

function Update () {
	transform.LookAt(LookAtTarget);
	
	var seconds : int = Time.time;
	var oddeven = (seconds % 2);
	
	if(oddeven)
		shoot(seconds);
}

function shoot(seconds){

	if(seconds != savedtime)
	{
		var bullet = Instantiate(bulletPreFab, transform.Find("turret1shot").transform.position, Quaternion.identity);
		
		bullet.rigidbody.AddForce(transform.forward*10);
		
		savedtime = seconds;
	}
}