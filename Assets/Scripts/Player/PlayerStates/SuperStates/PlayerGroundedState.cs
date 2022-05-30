 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    
    
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        player.physics.RemoveMod(player.Dash_Modifier);
        player.ghost_fx.renderOnMotion = false;
        player.DashManagerState.can_dash = true;
        player.AirState.doubleJumped = false;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        player.SetVelocityX(Input.x);
        player.physics.Flip((int)Input.x);
        if(!player.physics.On_ground && player.physics.velocity.y<=-0.5f){
            stateMachine.ChangeState(player.AirState);
        }else{
            if(Dash_Input){
                player.Input.UseDashInput();
                stateMachine.ChangeState(player.DashManagerState);
                isExitingState = true;
            }else
            if(JumpInput){
                player.Input.UseJumpInput();
                stateMachine.ChangeState(player.JumpState);
            
            }else if(Grab_Input && TouchingWall){
                stateMachine.ChangeState(player.GrabState);
            }else if(player.Stair != null && Input.y >0){
                stateMachine.ChangeState(player.OnStairState);
            }
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
