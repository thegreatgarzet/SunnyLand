using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    THIS SCRIPT IS A CUSTOM VERSION OF SEBASTIAN LAGUE PLATFORM CONTROLLER. ALL CREDITS GOES TO HIM, AS I
    ONLY CHANGE SOME THINGS TO MAKE HIS SCRIPTS WORK IN A BETTER WAY FOR MY PROJECT
*/
[RequireComponent (typeof (Controller2D))]
public class SL_Physics : MonoBehaviour
{
    public float maxJumpHeight = 4;
	public float minJumpHeight = 1;
	public float timeToJumpApex = .4f;
	
	float moveSpeed = 6;

	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;
    float gravity;
	float maxJumpVelocity;
	float minJumpVelocity;
	Vector3 velocity;
    float dir_input;
    Controller2D controller;

	void Awake() {
        controller = GetComponent<Controller2D> ();
		gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);    
    }

    void Update(){
        CalculateVelocity ();
    }
    public void CalculateVelocity (){
        velocity.x = dir_input * moveSpeed;
		velocity.y += gravity * Time.deltaTime;
        controller.Move (velocity * Time.deltaTime, Vector2.zero);
        if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}
    }
    public void SetDirInput(float dir){
        dir_input = dir;
    }
}
