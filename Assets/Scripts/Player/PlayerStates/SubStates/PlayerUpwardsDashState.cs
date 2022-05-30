using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpwardsDashState : PlayerAbilityState
{
    public bool can_dash=true;
    public PlayerUpwardsDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(0);
        

    }
    public override void Exit()
    {
        base.Exit();
        player.physics.ResetGravity();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Time.time >= startTime + playerData.AirDash_Anim_Timer){
            player.BaseJump();
            stateMachine.ChangeState(player.AirState);
            can_dash = false;
        }
    }
}
