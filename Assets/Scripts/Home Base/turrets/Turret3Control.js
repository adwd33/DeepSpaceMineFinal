var savedtime;
var bulletPreFab:Transform;
var misslePreFab:Transform;
var bombPreFab:Transform;
var gos : GameObject[];
var numEnemys;
var attEnemy;

static var type3:int;
static var level3:int;

var bombtime = 0;

function Start () {
	type3 = 1;
	attEnemy = 0;
	
	//gets all the enemys
	gos = GameObject.FindGameObjectsWithTag("enemy"); 
	
	numEnemys = gos.Length;
}


function Update () {

	//will only work if enemys are left
	if(GameObject.FindGameObjectsWithTag("enemy").Length > 0) {
		
		attEnemy = -1;
		//finds the first enemy within range to attack
		for(i = 0; i < numEnemys; i++){
			try{
				if(gos[i].transform.position.y <= 0){
					attEnemy = i;
					break;
				}
			} catch(err) {
			
			}
		}
	
		//will only look at enemy in line of sight
		if(attEnemy != -1){
			transform.LookAt(gos[attEnemy].transform);
				
			var seconds : int = Time.time;
			var oddeven;
				
			if(type3 == 3)
				oddeven = (seconds % 10);
			else 
				oddeven = (seconds % 2);
				
			if(oddeven)
				shoot(seconds);
				
			
			 bombtime++;
		 }
	 }
}
function shoot(seconds){

	if(type3 == 1)
	{
		if(seconds != savedtime)
		{
			var bullet = Instantiate(bulletPreFab, transform.Find("spawnpoint").transform.position, Quaternion.identity);
			
			bullet.rigidbody.AddForce(transform.forward*2000);
			
			savedtime = seconds;
		}
	}
	else if(type3 == 2)
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