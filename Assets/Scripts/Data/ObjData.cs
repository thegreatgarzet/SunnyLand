using UnityEngine;

[CreateAssetMenu(fileName = "ObjData", menuName = "SunnyLand/ObjData", order = 0)]
public class ObjData : ScriptableObject {

    [Header("JUMP")]
    public float maxJumpHeight = 4;

	public float minJumpHeight = 1;

	public float timeToJumpApex = .4f;

    [Header("Values changed on Enable")]
    public float maxJumpVelocity;

    public float minJumpVelocity; 

    public float gravity;

    public float ref_gravity;
    [Header("MOVEMENT")]
	public float moveSpeed;
    public float BasemoveSpeed = 6;
    private void OnEnable() {
        moveSpeed = BasemoveSpeed;
        ref_gravity = gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);  
    }
    private void OnDisable() {
        maxJumpVelocity = minJumpVelocity = ref_gravity = gravity = 0;
    }
}