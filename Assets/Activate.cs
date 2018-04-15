using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour {


    public GameObject go;

    public void activate()
    {
        go.SetActive(true);
    }

    public void deactivate()
    {
        go.SetActive(false);
    }

}
