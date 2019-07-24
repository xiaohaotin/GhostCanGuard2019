﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// なんのボタンが押されたか判定用
/// </summary>
public enum ControllerButton
{
    A,
    B,
    X,
    Y,
    Max,
    Null
}

public class InputManager : SingletonMonoBehavior<InputManager>
{
    /// <summary>
    /// 現在押されているボタン
    /// </summary>
    public ControllerButton CurrentControllerButton { get; private set; } = ControllerButton.Max;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) || Input.GetButtonDown("Cancel"))
            CurrentControllerButton = ControllerButton.A;
        if (Input.GetKeyDown(KeyCode.L) || Input.GetButtonDown("Send"))
        {
            CurrentControllerButton = ControllerButton.B;
            //Debug.Log("Send");
        }
            
        
        if (Input.GetKeyDown(KeyCode.J))
            CurrentControllerButton = ControllerButton.X;
        if (Input.GetKeyDown(KeyCode.I) || Input.GetButtonDown("Info"))
            CurrentControllerButton = ControllerButton.Y;
        else
            CurrentControllerButton = ControllerButton.Null;
    }
}
