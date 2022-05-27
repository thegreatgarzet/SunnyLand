using System.Collections;
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
        player.physics.Flip((int)Input.x);
        if(TouchingWall){
            if(Grab_Input){
                stateMachine.ChangeState(player.GrabState);
            }else{
                stateMachine.ChangeState(player.WSlideState);
            }
            
        }else{
            if(JumpInput){
                
                if(player.physics.Wall_dir()!=0){
                    player.Input.UseJumpInput();
                    stateMachine.ChangeState(player.WallJumpState);
                }
                else if(EnableDoubleJump && !doubleJumped){
                    doubleJumped =true;
                    player.Input.UseJumpInput();
                    stateMachine.ChangeState(player.JumpState);
                }
            }else if(player.Stair != null && Input.y >0 && Time.time >= startTime + playerData.GrabStair_Timer){
                stateMachine.ChangeState(player.OnStairState);
            }
      
            
            // if(player.physics.velocity.y<=0 && player.physics.On_ground){
            //     stateMachine.ChangeState(player.IdleState);
            // }
            player.TryIdle();
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
