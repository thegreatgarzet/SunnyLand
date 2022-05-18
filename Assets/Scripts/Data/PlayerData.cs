using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "SunnyLand/PlayerData", order = 0)]
public class PlayerData : ScriptableObject {
  
    [Header("Exposed Values")]
    public float maxJumpHeight = 4;

	public float minJumpHeight = 1;

	public float timeToJumpApex = .4f;
	
	public float moveSpeed = 6;
    
    [Header("Values changed on Enable")]
    public float maxJumpVelocity;

    public float minJumpVelocity; 

    public float gravity;

    public float ref_gravity;

    private void OnEnable() {
        ref_gravity = gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);  
    }
    private void OnDisable() {
        maxJumpVelocity = minJumpVelocity = ref_gravity = gravity = 0;
    }
}