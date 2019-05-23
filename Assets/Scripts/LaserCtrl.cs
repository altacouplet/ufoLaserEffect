using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCtrl : MonoBehaviour {

    [Header("UFO攻撃中")]
    public bool ufoLaserAttack;

    public int Attackrate = 100;

    private LineRenderer lr;
    public GameObject ufoCube;
    public GameObject targetCube;
    
	void Start () {
        lr = GetComponent<LineRenderer>();

        ufoLaserAttack = false;
    }

    void Update()
    {

        lr.SetPosition(0, ufoCube.transform.position);

        if (!ufoLaserAttack)
        {
            if (Random.Range(0, Attackrate) < 2)
            {
                ufoLaserAttack = true;
            }
            lr.SetPosition(1, ufoCube.transform.position);
        }

        if (ufoLaserAttack)
        {
            lr.SetPosition(1, targetCube.transform.position);

            if (targetCube.GetComponent<CubeCtrl>().burned == true)
            {
                ufoLaserAttack = false;
                targetCube.GetComponent<CubeCtrl>().burned = false;
            }
        }

    }
}
