
/*
    Criado por Garzet Dev

    2017 - 2021
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
   
    public bool Jump_Input, Jump_Input_Hold;
    public bool Grab_Input, Grab_Input_Hold;
    public bool Dash_Input, Dash_Input_Hold;
    
    [SerializeField]Vector2 Dir_input;
    InputAction.CallbackContext jump_context;
    public void GetMove(InputAction.CallbackContext context){
        Vector2 raw_input = context.ReadValue<Vector2>();

        Dir_input.x = (int)(raw_input * Vector2.right).normalized.x;
        Dir_input.y = (int)(raw_input * Vector2.up).normalized.y;
    }
    public void GetJumpInput(InputAction.CallbackContext context){
        jump_context = context;
        if(context.started){
            Jump_Input_Hold = Jump_Input = true;
            
        }
        if(context.canceled){
            Jump_Input_Hold = Jump_Input = false;
            
        }
    }
    public void GetGrabInput(InputAction.CallbackContext context){
        
        if(context.started){
            Grab_Input_Hold = Grab_Input = true;
            
        }
        if(context.canceled){
            Grab_Input_Hold = Grab_Input = false;
            
        }
    }
    public void GetDashInput(InputAction.CallbackContext context){
        
        if(context.started){
            Dash_Input_Hold = Dash_Input = true;
            
        }
        if(context.canceled){
            Dash_Input_Hold = Dash_Input = false;
            
        }
    }
    public Vector2 GetDirInput(){
        return Dir_input;
    }
    public InputAction.CallbackContext JumpContext(){
        return jump_context;
    }
    public void UseJumpInput() => Jump_Input = false;
    public void UseDashInput() => Dash_Input = false;
    void Update(){
        if(Input.GetKeyDown(KeyCode.F)){
            SceneManager.LoadScene(0);
        }
    }
}
