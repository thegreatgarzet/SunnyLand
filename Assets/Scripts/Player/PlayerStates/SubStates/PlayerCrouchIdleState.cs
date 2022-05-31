 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchIdleState : PlayerGroundedState
{
    
    
    public PlayerCrouchIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        player.SetColliderHeight(playerData.Crouch_Height);
    }

 
    public override void Exit()
    {
        base.Exit();
        player.SetColliderHeight(playerData.Normal_Height);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if(Input.x !=0){
            stateMachine.ChangeState(player.CrouchMoveState);
        }else if(Input.y >=0 && !player.DetectCeiling()){
            stateMachine.ChangeState(player.IdleState);
        }
    }
}
