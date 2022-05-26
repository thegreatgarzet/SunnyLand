﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    public bool doubleJumped=false;
    bool EnableDoubleJump;
    
    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        EnableDoubleJump = playerData.EnableDoubleJump;
    }
    
    
    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
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
        
        if(TouchingWall){
            if(Grab_Input){
                stateMachine.ChangeState(player.GrabState);
            }else{
                stateMachine.ChangeState(player.WSlideState);
            }
            
        }else{
            if(EnableDoubleJump){
                if(JumpInput && !doubleJumped){
                    doubleJumped =true;
                    player.Input.UseJumpInput();
                    stateMachine.ChangeState(player.JumpState);
                }
            }
      
            
            if(player.physics.velocity.y<=0 && player.physics.On_ground){
                stateMachine.ChangeState(player.IdleState);
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