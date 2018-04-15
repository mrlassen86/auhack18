using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastReceiver : MonoBehaviour {

    private RaycastSender RaySender;
    float RayRunsOutTime;
    private CircuitComponent CircuitComponent;

    [Header("General")]
    public Transform _AimPoint;
    public float HitByRayRefreshTime = 1f;
    public bool IsHitByRay = false;

    void Start()
    {
        CircuitComponent = GetComponent<CircuitComponent>();
        RaySender = GetComponent<RaycastSender>();
        //Initialize run out time.
        RayRunsOutTime = Time.time;
    }

    void Update()
    {
        if (Time.time > RayRunsOutTime)
        { //check if time run out, if it has, no longer being hit by ray.
            IsHitByRay = false;
        }
        else
        {
            RaySender.ReceiverActivateSender(_AimPoint);
        }
    }

    public void HitWithRay(int circuitId)
    { //method activated by ray sender when hitting this target.
        IsHitByRay = true;
        RayRunsOutTime = Time.time + HitByRayRefreshTime;
        CircuitComponent.setCircuitID(circuitId);
    }
}
