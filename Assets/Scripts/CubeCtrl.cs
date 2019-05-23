using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCtrl : MonoBehaviour
{
    private MegaShapeFollow msf;
    public GameObject Laser;
    private Vector3 oldPos;

    LaserCtrl LaserScript;
    
    public GameObject FireEffect;
    private GameObject fe;

    MegaPathTarget target;
    public MegaShapeLine msl1;
    public MegaShapeLine msl2;
    public MegaShapeLine msl3;
    public int bunki;

    [Header("MegaShape移動速度")]
    public float TargetCubeSpeed = 1000.0f;
    [Header("レーザーが撤退する時のAlpha値")] // MegaShapeFollowのAlpha値
    public float LineDeleteAlpha = 1.1f;

    [Header("パーティクル生成間隔")]
    public float waitTime = 0.05f;
    private float elaspedTime;

    public bool burned;
    public bool TargetSwitched = false;

    void Start()
    {
        msf = GetComponent<MegaShapeFollow>();

        Laser = GameObject.Find("Laser");
        LaserScript = Laser.GetComponent<LaserCtrl>();

        msf.Alpha = 0f;
    }

    void Update()
    {
        elaspedTime += Time.deltaTime;

        if (LaserScript.ufoLaserAttack == true)
        {
            msf.speed = TargetCubeSpeed;
            TargetSwitched = false;

            // 前回位置と現在位置が異なるとき、炎パーティクルを表示
            if (oldPos != transform.position)
            {
                // タイマー（パーティクル生成間隔調整）
                if (elaspedTime > waitTime)
                {
                    fe = Instantiate(FireEffect.gameObject, transform.position + Vector3.up * 1f, Quaternion.identity);
                    fe.transform.localScale = new Vector3(10, 10, 10);

                    elaspedTime = 0f;
                }
            }
        }
        Destroy(fe, 4.0f);


        // レーザーがMegaShapes終点まで移動したらフラグON
        if (msf.Alpha > LineDeleteAlpha)
        {
            burned = true;

            if (!TargetSwitched)
            {
                msf.Alpha = 0f;
                msf.speed = 0;
                SwitchTarget();
                TargetSwitched = true;
            }
        }

        // 値の記録
        oldPos = transform.position;

    }

    void SwitchTarget()
    {
        target = msf.Targets[0];

        bunki = Random.Range(1, 4);

        switch (bunki)
        {

            case 1:
                target.shape = msl1;
                break;

            case 2:
                target.shape = msl2;
                break;

            case 3:
                target.shape = msl3;
                break;

        }

        msf.Alpha = 0;

        return;
    }
}
