using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InputManager Input;
    public SL_Physics physics;
    #region STATE MACHINE SHENANIGANS
    public PlayerStateMachine StateMachine{get; private set;}
    //STATES
    public PlayerIdleState IdleState {get; private set;}
    public PlayerMoveState MoveState {get; private set;}
    public PlayerJumpState JumpState {get; private set;}
    public PlayerInAirState AirState {get; private set;}
    public PlayerLandState LandState {get; private set;}

    public PlayerWallClimbState ClimbState{get; private set;}
    public PlayerWallGrabState GrabState{get; private set;}
    public PlayerWallSlideState WSlideState{get; private set;}

    public PlayerWallJumpStateLoA WallJumpState{get; private set;}

    #endregion
    public Animator Anim;
    [SerializeField]PlayerData playerData;
    [Header("CURRENT ANIMATION")]
    public string CurrentAnimName;
    
    private void Awake() {
        StateMachine = new PlayerStateMachine();
        Input = GetComponent<InputManager>();
        Anim = GetComponent<Animator>();
        physics = GetComponent<SL_Physics>();
        //CREATE STATES
            IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
            MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
            JumpState = new PlayerJumpState(this, StateMachine, playerData, "jump");
            AirState = new PlayerInAirState(this, StateMachine, playerData, "jump");
            LandState = new PlayerLandState(this, StateMachine, playerData, "land");
            ClimbState = new PlayerWallClimbState(this, StateMachine, playerData, "climb");
            GrabState = new PlayerWallGrabState(this, StateMachine, playerData, "grab");
            WSlideState = new PlayerWallSlideState(this, StateMachine, playerData, "slide");
            WallJumpState =  new PlayerWallJumpStateLoA(this, StateMachine, playerData, "jump");
        //
    }
    void Start(){
        StateMachine.Initialize(IdleState);
    }
    void Update(){
        StateMachine.CurrentState.LogicUpdate();
        StateMachine.CurrentState.PhysicsUpdate();
        UpdateAnimValues();
        CurrentAnimName = StateMachine.CurrentState.ToString();
    }
    public void SetVelocityX(float x){
        physics.velocity.x = x * playerData.moveSpeed;
    }
    public void SetVelocityY(float y){
        physics.velocity.y = y;
    }
    public void BaseJump(){
        SetVelocityY(playerData.maxJumpVelocity);
    }
    void UpdateAnimValues(){
        Anim.SetFloat("y", physics.velocity.y);
    }
    public void PlayerSetValues(PlayerData data){
        physics.gravity = data.gravity;
        
    }
    public bool TryIdle(){
        if(physics.velocity.y<=0 && physics.On_ground){
            StateMachine.ChangeState(IdleState);
            return true;
        }else{
            return false;
        }
    }
}
