

function Start () {
	transform.LookAt(GameObject.FindGameObjectWithTag("HomeBase").transform);
	rigidbody.AddForce(transform.forward*50);
}

function Update () {

}
