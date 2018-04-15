using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroScript : MonoBehaviour {



    public float HitByRayRefreshTime = 1f;
    float RayRunsOutTime;

    bool Activated = false;

    private void Update()
    {
        if (Time.time > RayRunsOutTime && Activated)
        {
            deactivateCircuit();
        }
    }

    public void activateCircuit()
    {
        Activated = true;
        RayRunsOutTime = Time.time + HitByRayRefreshTime;
        if (!(Time.time > 2f))
        {
            return;
        }
        GameObject[] go = GameObject.FindGameObjectsWithTag("LEGOBrick");
        foreach (var g in go)
        {
            Activate a = g.GetComponent<Activate>();
            if(a != null)
            {
                a.activate();
            }
        }
    }

    public void deactivateCircuit()
    {
        Activated = false;
        GameObject[] go = GameObject.FindGameObjectsWithTag("LEGOBrick");
        foreach (var g in go)
        {
            Activate a = g.GetComponent<Activate>();
            if (a != null)
            {
                a.deactivate();
            }
        }
    }
}
