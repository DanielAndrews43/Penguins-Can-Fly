#pragma strict

var force : Vector2;
var speed : float;
var jump : KeyCode;


function Update () {
	if(Input.GetKeyDown(jump)){
		GetComponent.<Rigidbody2D>().AddForce(force);
	}
	GetComponent.<Rigidbody2D>().velocity.x = speed;
}

function FixedUpdate (){
	if(GetComponent.<Rigidbody2D>().velocity.y > 10){
		GetComponent.<Rigidbody2D>().velocity.y = 10;
	}
}