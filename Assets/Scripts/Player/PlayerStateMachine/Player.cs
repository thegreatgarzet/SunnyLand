using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class Player : MonoBehaviour
{
    public InputManager Input;
    public SL_Physics physics;
    
    #region STATE MACHINE SHENANIGANS
    [TabGroup("STATES")]
    public PlayerStateMachine StateMachine{get; private set;}
    [TabGroup("STATES")]
    //STATES
    public PlayerIdleState IdleState {get; private set;}
    [TabGroup("STATES")]
    public PlayerMoveState MoveState {get; private set;}
    [TabGroup("STATES")]
    public PlayerJumpState JumpState {get; private set;}
    [TabGroup("STATES")]
    public PlayerInAirState AirState {get; private set;}
    [TabGroup("STATES")]
    public PlayerLandState LandState {get; private set;}
    [TabGroup("STATES")]

    public PlayerWallClimbState ClimbState{get; private set;}
    [TabGroup("STATES")]
    public PlayerWallGrabState GrabState{get; private set;}
    [TabGroup("STATES")]
    public PlayerWallSlideState WSlideState{get; private set;}
    [TabGroup("STATES")]

    public PlayerWallJumpStateLoA WallJumpState{get; private set;}
    [TabGroup("STATES")]

    public PlayerOnStairState OnStairState{get; private set;}
    [TabGroup("STATES")]
    public PlayerDashManagerState DashManagerState{get; private set;}
    [TabGroup("STATES")]
    public PlayerCrouchIdleState CrouchIdleState{get; private set;}
    [TabGroup("STATES")]
    public PlayerCrouchMoveState CrouchMoveState{get; private set;}
    #endregion
    public Transform Stair;
    public Animator Anim;
    [SerializeField]PlayerData playerData;
    public GhostSprites ghost_fx;
    
    
    [TabGroup("MODIFIERS")]
    public Status_Modifier Dash_Modifier;
    [Header("CURRENT ANIMATION")]
    public string CurrentAnimName;
    
    private void Awake() {
        StateMachine = new PlayerStateMachine();
        Input = GetComponent<InputManager>();
        Anim = GetComponent<Animator>();
        physics = GetComponent<SL_Physics>();
        ghost_fx = GetComponent<GhostSprites>();
        ghost_fx.renderOnMotion = false;
        //CREATE STATES
            IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
            MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
            JumpState = new PlayerJumpState(this, StateMachine, playerData, "jump");
            AirState = new PlayerInAirState(this, StateMachine, playerData, "jump");
            LandState = new PlayerLandState(this, StateMachine, playerData, "land");

            CrouchIdleState = new PlayerCrouchIdleState(this, StateMachine, playerData, "crouch");
            CrouchMoveState = new PlayerCrouchMoveState(this, StateMachine, playerData, "crouchmove");

            ClimbState = new PlayerWallClimbState(this, StateMachine, playerData, "climb");
            GrabState = new PlayerWallGrabState(this, StateMachine, playerData, "grab");
            WSlideState = new PlayerWallSlideState(this, StateMachine, playerData, "slide");
            WallJumpState =  new PlayerWallJumpStateLoA(this, StateMachine, playerData, "jump");

            
            OnStairState = new PlayerOnStairState(this, StateMachine, playerData, "stair_idle");

            DashManagerState = new PlayerDashManagerState(this, StateMachine, playerData, "dash");
            DashManagerState.Dash_Mod = Dash_Modifier;
            
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
        physics.velocity.x = x * physics.move_speed;
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("stair")){
            Stair = other.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("stair")){
            Stair = null;
        }
    }
}
