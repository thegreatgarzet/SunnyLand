using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpStateLoA : PlayerAbilityState
{
    public int dir_modifier;
    public float wall_jump_timer = .2f;
    public PlayerWallJumpStateLoA(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }
    public override void Enter(){
        base.Enter();
        wall_jump_timer = playerData.WallJump_Timer;
        dir_modifier = player.physics.Wall_dir();
        player.SetVelocityX(dir_modifier);
        player.BaseJump();
    }
    public override void LogicUpdate(){
        base.LogicUpdate();
        player.TryIdle();
        if(Time.time >= startTime + wall_jump_timer){
            stateMachine.ChangeState(player.AirState);
        }
    }
}
