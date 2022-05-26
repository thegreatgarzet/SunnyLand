﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallGrabState : PlayerOnWallState
{
    public PlayerWallGrabState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
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
        player.SetVelocityY(0);
        player.physics.SetGravity(0);
        base.LogicUpdate();
        
        if(Input.y!=0){
            if(Input.y>0){
                stateMachine.ChangeState(player.ClimbState);
            }else if(Input.y<0 || !Grab_Input){
                stateMachine.ChangeState(player.WSlideState);
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