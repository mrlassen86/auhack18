using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circuit : MonoBehaviour {

    public List<Transform> _CircuitComponents;

    public void AddToCircuit(Transform t) {
        Debug.Log("Adding: "+t.name);
        if (!_CircuitComponents.Contains(t))
        {
            _CircuitComponents.Add(t);
        }
    }
}
