﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class testStatue : GimmickBase
{
    public float thrust;
    public Rigidbody rb;


    public float smooth = 3f;
    float tiltAngle = 0f;

    bool isFallen = false;

    public GameObject tiltpoint;
    float tiltAroundX = 0f;
    float tiltAroundZ = 0f;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        GimmickEventSetUp(EventTriggerType.PointerDown, GimmickEventOpen);
        rb.isKinematic = true;
        tiltAroundX = 0f;
        tiltAroundZ = 0f;
        tiltAngle = 0f;
        transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);


    }

    private void FixedUpdate()
    {
        Quaternion target = Quaternion.Euler(tiltAroundX, transform.rotation.eulerAngles.y, tiltAroundZ);

        //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        if (Mathf.Abs(transform.rotation.eulerAngles.x) < tiltAngle)
        {
            transform.RotateAround(tiltpoint.transform.position, transform.right, smooth);

        }
        
        if (isFallen)
        {
            transform.position = new Vector3(transform.localPosition.x, 0.5f, transform.localPosition.z);
        }
        
    }
    //private void Update()
    //{
    //    if (Input.GetButtonDown("Send") && st.selectedObject == gameObject)
    //    {
    //        FallForwards();
    //    }
    //}
    // for buttons
    public void FallRight()
    {
        tiltAroundZ = tiltAngle;
        //rb.AddForce(transform.right * thrust);
        GimmickUIClose();
    }

    public void FallLeft()
    {
        tiltAroundZ = -tiltAngle;
        //rb.AddForce(-transform.right * thrust);
        GimmickUIClose();
    }

    public void FallForwards()
    {
        if (!isFallen)
        {
            tiltAngle = 90f;
            isFallen = true;
            st.gamestop();
            GimmickUIClose();
        }
       
        //rb.AddForce(transform.forward * thrust);

    }

    public void FallBackwards()
    {
        tiltAroundX = -tiltAngle;
        //rb.AddForce(-transform.forward * thrust);
        GimmickUIClose();
    }

    public void resetPillar()
    {
        tiltAroundX = 0;
        tiltAroundZ = 0;
        isFallen = false;
    }


    public void CloseUI()
    {
        GimmickUIClose();
    }
    protected override void PushButtonGamePad(ControllerButton controller)
    {
        base.PushButtonGamePad(controller);
        switch (controller)
        {
            case ControllerButton.A:
                break;
            case ControllerButton.B:
                Debug.Log("Send");
                FallForwards();
                break;
            case ControllerButton.X:
                break;
            case ControllerButton.Y:
                break;
            case ControllerButton.Max:
                break;
            default:
                break;
        }
    }
}
