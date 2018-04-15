using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSender : MonoBehaviour {

    RaycastHit Hit;
    RaycastReceiver RaycastReceiver;
    float SendRefreshTime;
    private CircuitComponent CircuitComponent;
 
    [Header("Booleans")]
    [Tooltip("if powersource, should be false.")]
    public bool _UseReceiver;
    [Header("General")]
    public Transform _AimPoint;
    public float ShouldSendRefreshTime = 0.05f;
    public List<string> _TargetableTags = new List<string>() { "LEGOBrick" };
    [Header("For observation only")]
    [Tooltip("True if powersource, if not, true if hit by ray, should only be set by scripts.")]
    public bool _SendRays;

    void Start()
    {
        SendRefreshTime = Time.time;
        CircuitComponent = GetComponent<CircuitComponent>();
    }

    void FixedUpdate()
    {
        if (!_SendRays && _UseReceiver)
            return;

        PerformRaycast();
        //SendRaycast and store in 'Hit'.
        if (Hit.collider != null)
        { //If raycast hit a collider, attempt to acquire its receiver script.
            RaycastReceiver = Hit.collider.gameObject.GetComponent<RaycastReceiver>();

            if (RaycastReceiver != null)
            { //if receiver script acquired, hit it.
                RaycastReceiver.HitWithRay(CircuitComponent.getCircuitID());
            }
            ZeroScript a = Hit.collider.gameObject.GetComponent<ZeroScript>();
            if (a != null)
            {
                a.activateCircuit();
            }
        }

        CheckIfShouldSendRays();
    }

    private void CheckIfShouldSendRays()
    {
        if (Time.time > ShouldSendRefreshTime)
        {
            _SendRays = false;
        }
    }

    public void ReceiverActivateSender(Transform aimPoint) {

        _SendRays = true;
        ShouldSendRefreshTime = Time.time + SendRefreshTime;

        if (aimPoint != null)
        {
            _AimPoint = aimPoint;
        }
    }

    GameObject PerformRaycast() {
        if (_AimPoint == null)
            return null;

        Debug.Log(name + " sends rays.");
        GameObject go = null;
        Vector3 fwd = _AimPoint.TransformDirection(Vector3.up);
        Debug.DrawRay(_AimPoint.position, fwd * 50, Color.green);
        if (Physics.Raycast(transform.position, fwd, out Hit, 50))
        {
            if ( Hit.collider == null)
            {
                return null;
            }
            go  = Hit.collider.gameObject;
            if (go != null)
            {
                if (_TargetableTags.Contains(go.transform.tag))
                {
                    Debug.Log("Hit object: "+go.name);
                }
            }
            
        }
        return go;
    }
}
