/*
    Criado por Garzet Dev

    2017 - 2021
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
   
    public bool Jump_Input;
    Vector2 Dir_input;
    public void GetMove(InputAction.CallbackContext context){
        Vector2 raw_input = context.ReadValue<Vector2>();

        Dir_input.x = (int)(raw_input * Vector2.right).normalized.x;
        Dir_input.y = (int)(raw_input * Vector2.up).normalized.y;
    }
    public void GetJumpInput(InputAction.CallbackContext context){
        if(context.started){
            Jump_Input = true;
        }
        if(context.canceled){
            Jump_Input = false;
        }
    }
    public Vector2 GetDirInput(){
        return Dir_input;
    }
    public void UseJumpInput() => Jump_Input = false;
    void Update(){
        if(Input.GetKeyDown(KeyCode.C)){
            SceneManager.LoadScene(0);
        }
    }
}
