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

    #endregion
    public Animator Anim;
    [SerializeField]PlayerData playerData;
    
    private void Awake() {
        StateMachine = new PlayerStateMachine();
        Input = GetComponent<InputManager>();
        Anim = GetComponent<Animator>();
        physics = GetComponent<SL_Physics>();
        //CREATE STATES
            IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
            MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
            JumpState = new PlayerJumpState(this, StateMachine, playerData, "jump");
            AirState = new PlayerInAirState(this, StateMachine, playerData, "inair");
            LandState = new PlayerLandState(this, StateMachine, playerData, "land");
        //
    }
    void Start(){
        StateMachine.Initialize(IdleState);
    }
    void Update(){
        StateMachine.CurrentState.LogicUpdate();
        StateMachine.CurrentState.PhysicsUpdate();
        UpdateAnimValues();
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
}
