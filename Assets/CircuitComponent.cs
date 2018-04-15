using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitComponent : MonoBehaviour {

    [SerializeField] private int CircuitID;

    public void setCircuitID(int ID)
    {
        CircuitID = ID;
    }

    public int getCircuitID()
    {
        return CircuitID;
    }

}
