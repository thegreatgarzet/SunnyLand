using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        player.BaseJump();
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
        // if(player.physics.velocity.y<=0 && player.physics.On_ground){
        //     stateMachine.ChangeState(player.IdleState);
        // }
        if(player.physics.velocity.y<=0){
            if(player.physics.On_ground){
                stateMachine.ChangeState(player.IdleState);
            }else{
                stateMachine.ChangeState(player.AirState);
            }
        }else if(player.Stair != null && Input.y >0 && Time.time >= startTime + playerData.GrabStair_Timer){
                stateMachine.ChangeState(player.OnStairState);
            }
        if(!player.Input.Jump_Input_Hold && player.physics.velocity.y > 0){
            player.SetVelocityY(0);
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
