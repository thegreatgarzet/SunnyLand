﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallClimbState : PlayerOnWallState
{
    public PlayerWallClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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



    public override void Exit()
    {
        base.Exit();
    }



    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Input.y<=0){
            stateMachine.ChangeState(player.WSlideState);
        }
        player.SetVelocityY(1);
    }


}
