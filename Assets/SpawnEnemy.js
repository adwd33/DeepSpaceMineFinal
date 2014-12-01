#pragma strict

var  enemy:Transform;
var x = 0;
var y = 0;
var z = 0;
var i = 0;
function Start () {
	
}

function Update () {

	if(GameObject.FindGameObjectsWithTag("enemy").Length == 0)
		i = 0;
	while(i < 5)
	{
		
			x = Random.Range(-10,10);
		
			y = Random.Range(-10,10);
		
			z = Random.Range(-10,10);
			
		var newenemy = Instantiate(enemy, Vector3(x,y,z), Quaternion.identity);
		i++;
	}
}