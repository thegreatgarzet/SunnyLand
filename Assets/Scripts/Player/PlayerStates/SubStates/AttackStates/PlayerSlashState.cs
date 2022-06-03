using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlashState : PlayerAbilityState  
{ 
    //GENERAL STATE FOR SWORD TYPE MOVE, ON ENTER, I SHOULD CHECK FOR OTHER TYPES OF 
    //INPUTS AND THEN CHOOSE WHAT MOVE THE PLAYER SHOULD DO
    //EXAMPLE, IF PRESSING UP, ENTER ASCENDING SWORD STATE
    //FOR THE PROTOTYPE, IT WILL ONLY CHECK FOR AIR AND GROUND SLASH
    public PlayerGroundSlashState GroundSlashState{get; private set;}
    public PlayerAirSlashState AirSlashState{get; private set;}
    public PlayerSlashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        AirSlashState = new PlayerAirSlashState(player, stateMachine, playerData, "airslash");
        GroundSlashState = new PlayerGroundSlashState(player, stateMachine, playerData, "groundslash1");
    }
    public override void Enter()
    {
        base.Enter();
        
        if(player.physics.On_ground){
            stateMachine.ChangeState(GroundSlashState);
        }else{
            stateMachine.ChangeState(AirSlashState);
        }
    }
    public override void Exit()
    {
        
    }
}
