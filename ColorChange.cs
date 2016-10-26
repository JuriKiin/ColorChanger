using UnityEngine;
using System.Collections;

// Juri Kiin
// September 2016
// Jurikiin.com

public class ColorChange : MonoBehaviour {

	public Material colorMaterial;	//This gets the material.
	public Color color;	//This determines the color of the material.
	public float movementThreshold = .5f;	//This is how sensitive we want the accellerometer to be.

	public float colorChangeFactor = .25f;	//The increment by how much we will change the color.
	public int changeSpeed = 4;	//How quickly we will change the color.

	public float tempR;	//This gets the r value of the current frame.

	void Start()
	{
		color = colorMaterial.color;	//Set the start material to blue (No movement)
		color = Color.blue;	//Set the color.
	}

	void Update () {

		if (color.r > 0) {	//If we are blue, stop making it more blue.
			tempR = color.r;
		}


		color.r -= changeSpeed *colorChangeFactor * Time.deltaTime;	//Change the r value constantly.
		color.b += changeSpeed *colorChangeFactor * Time.deltaTime;	//Change the b value constantly.


		if (Input.acceleration.magnitude > movementThreshold) {
			//Our device is moving above the threshold. Change the color

			if (color.r < 1) {
				color.r += colorChangeFactor;	//Change r value.
				color.b -= colorChangeFactor;	//Change b value.
			}
			Debug.Log ("We are above the threshold.");	//Debug that we are above threshold.
		} 

		colorMaterial.color = color;	//Set the color at the end of the frame.

	}
}
