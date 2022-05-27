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
	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;
    public float gravity;
    [SerializeField]float ref_gravity;
	float maxJumpVelocity;
	float minJumpVelocity;
	public Vector3 velocity;
    float dir_input;
    public bool can_flip=true;
    public bool On_ground{get;private set;}
    
    public Controller2D controller;
    private object player;

    void Awake() {
        
        controller = GetComponent<Controller2D> ();
		ref_gravity = gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);    
    }

    void Update(){
        CalculateVelocity ();
        On_ground = controller.collisions.below;
        
    }
    public void CalculateVelocity (){
        
		velocity.y += gravity * Time.deltaTime;
        controller.Move (velocity * Time.deltaTime, Vector2.zero);
        if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
            
		}
    }
    public void SetDirInput(float dir){
        dir_input = dir;
    }
    public void SetSpeed(){
        
    }
    
    public void ResetSpeed(){

    }
    public void SetGravity(float g){
        gravity = g;
    }
    public void ResetGravity(){
        print("Gravity Reset");
        gravity = ref_gravity;
    }
    public void Flip(int x){
        if(x!=0 && can_flip){
            transform.localScale = new Vector2(x, 1);
        }
    }
    public int Wall_dir(){
        int dir = 0;
        dir = controller.collisions.left?1:controller.collisions.right?-1:0;
        return dir;
    }
}
