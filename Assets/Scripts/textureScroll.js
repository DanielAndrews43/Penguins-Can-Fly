#pragma strict

var speed : float;

function Update () {

	var offset : Vector2 = new Vector2 (Time.time * speed, 0);

	GetComponent.<Renderer>().material.mainTextureOffset = offset;

}