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
        player.SetVelocityX(playerData.moveSpeed * dir_modifier);
        player.BaseJump();
    }
    public override void LogicUpdate(){
        base.LogicUpdate();
        player.TryIdle();
    }
}
