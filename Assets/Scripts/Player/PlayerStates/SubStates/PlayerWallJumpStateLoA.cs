using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpStateLoA : PlayerAbilityState
{
    public int dir_modifier;
    
    public PlayerWallJumpStateLoA(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }
    public override void Enter(){
        base.Enter();
        dir_modifier = player.physics.Wall_dir();
        player.SetVelocityX(dir_modifier);
        player.BaseJump();
    }
    public override void LogicUpdate(){
        base.LogicUpdate();
        if(Time.time >= startTime + playerData.WallJump_Timer){
            stateMachine.ChangeState(player.AirState);
        }
        player.TryIdle();
    }
}
