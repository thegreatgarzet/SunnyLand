using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public float move_speed;
    float base_movespeed;

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
    [SerializeField]public bool On_ground;
    
    public Controller2D controller;
    private object player;
    private List<Status_Modifier> modifiers;
    Rigidbody2D rb;

    void Awake() {
        modifiers = new List<Status_Modifier>();
        rb = GetComponent<Rigidbody2D>(); 
        controller = GetComponent<Controller2D> ();
		ref_gravity = gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);    
        base_movespeed = move_speed;
    }

    void Update(){
        CalculateVelocity ();
        On_ground = controller.collisions.below;
        
    }
    public void CalculateVelocity (){
        
		velocity.y += gravity * Time.deltaTime;
        rb.velocity = velocity;
        controller.Move (velocity * Time.deltaTime, Vector2.zero);
        if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
            
		}
    }
    public void SetDirInput(float dir){
        dir_input = dir;
    }
    public void SetSpeed(float x){
        
    }
    
    public void ResetSpeed(){
        move_speed = base_movespeed;
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
    public void AddModofier(Status_Modifier mod){
        if(mod.using_mod)
            return;
        move_speed += mod.Speed_Mod;
        mod.using_mod = true;
    }
    public void RemoveMod(Status_Modifier mod){
        if(!mod.using_mod)
            return;
        move_speed -= mod.Speed_Mod;
        mod.using_mod = false;
    }
}
