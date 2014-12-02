#pragma strict
var explosion:Transform;
static var health:int;

static var currHealth:int;
static var healthRate:int;
var healthTime = 0;

function Start () {
	health = 60;
	currHealth = 60;
	healthRate = 7;
}

function Update () {
	if(currHealth < health && Time.time > healthTime)
	{
		currHealth++;
		healthTime = Time.time + healthRate;
	}
}

function OnTriggerEnter (other : Collider) {
	if (other.tag == "boundary" || other.tag == "nuclearshot" || other.tag == "TurretShot" || other.tag == "missile")
		{
			return;
		}
		currHealth--;
		currHealth--;
		var exp = Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
		Destroy(other.gameObject);
		if (currHealth > 0) {
			return;
		}
		else
		{
			
			Destroy(gameObject);
			Destroy(GameObject.Find("turret1"));
			Destroy(GameObject.Find("turret2"));
			Destroy(GameObject.Find("turret3"));
			Destroy(GameObject.Find("turret4"));
			Destroy(GameObject.Find("turret5"));
			Destroy(GameObject.Find("turret6"));
		}
}