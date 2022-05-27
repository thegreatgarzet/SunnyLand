using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnWallState : PlayerState
{
    public PlayerOnWallState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        player.physics.ResetGravity();
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(TouchingWall){
            if(player.physics.velocity.y<=0 && player.physics.On_ground){
                stateMachine.ChangeState(player.IdleState);
            }
            if(JumpInput){
                player.Input.UseJumpInput();
                
                stateMachine.ChangeState(player.WallJumpState);
                
                Debug.Log("Velocity" + player.physics.velocity);
            }
        }else{
            stateMachine.ChangeState(player.AirState);
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
