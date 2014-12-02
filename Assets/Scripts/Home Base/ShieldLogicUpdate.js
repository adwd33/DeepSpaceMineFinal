#pragma strict
var explosion:Transform;
static var shieldStrength : int;

static var currshieldStrength:int;
static var shieldRate;
var shieldTime = 0;

function Start () {
	shieldStrength = 80;
	shieldRate = 5.5;
	currshieldStrength = 80;
}

function Update () {
	if(currshieldStrength < shieldStrength && Time.time > shieldTime)
	{
		currshieldStrength++;
		shieldTime = Time.time + shieldRate;
	}
}

function OnTriggerEnter (other : Collider) {
		if (other.tag == "boundary" || other.tag == "TurretShot" || other.tag == "missile" || other.tag == "nuclearshot")
		{
			return;
		}
		currshieldStrength--;
		currshieldStrength--;
		var exp = Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
		Destroy(other.gameObject);
		if (currshieldStrength > 0) {
			return;
		}
		else
		{
			Destroy(gameObject);
		}
}