using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoCtrl : MonoBehaviour {

    private MegaShapeFollow msf;
    public float ufoSpeed = 100f;

    void Start () {
        msf = GetComponent<MegaShapeFollow>();

        msf.speed = ufoSpeed;
    }

	void Update () {
		if(msf.Alpha > 1.9989f)
        {
            msf.Alpha = 0f;
        }
	}
}
