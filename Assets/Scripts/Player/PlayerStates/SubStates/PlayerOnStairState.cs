using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnStairState : PlayerAbilityState
{
    public int dir_modifier;
    bool using_move=false;
    
    public PlayerOnStairState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }

    public override void Enter(){
        base.Enter();
        player.physics.SetGravity(0);
        player.SetVelocityX(0);
        player.transform.position = new Vector2(player.Stair.position.x, player.transform.position.y);
    }
    public override void LogicUpdate(){
        base.LogicUpdate();
        if(player.Stair !=null){
            if(JumpInput){
                player.Input.UseJumpInput();
                stateMachine.ChangeState(player.AirState);
            }else{
                player.SetVelocityY(Input.y * playerData.StairClimb_Speed);
                if(Input.y!=0){
                    if(!using_move){
                        player.sp_anim.Play("stairmoving");
                        using_move = true;
                    }
                    
                }else{
                    using_move = false;
                    player.sp_anim.Play("stair");
                }
            }
        }else{
            player.BaseJump();
            stateMachine.ChangeState(player.AirState);
        }
        
    }
    public override void Exit()
    {
        base.Exit();
        
        player.physics.ResetGravity();
        using_move = false;
    }

}
