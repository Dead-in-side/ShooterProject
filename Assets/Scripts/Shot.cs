using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private AudioSource FireShot;
    [SerializeField] private AudioSource Recharge;
    [SerializeField] private Animator AnimShot;
    private bool DoomShoot;

    void Start()
    {
        AnimShot = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AnimShot.SetBool("Shot", true);
        }

        if (Input.GetKey(KeyCode.W) && !Input.GetMouseButtonDown(0))
        {
            AnimShot.SetBool("Run", true);
        }
        else
        {
            AnimShot.SetBool("Run", false);
        }

        if (Input.GetKey(KeyCode.S) && !Input.GetMouseButtonDown(0))
        {
            AnimShot.SetBool("BackRun", true);
        }
        else
        {
            AnimShot.SetBool("BackRun", false);
        }
    }

    public void Attack()
    {
        AnimShot.SetBool("Shot", false);
    }

    public void FireSource()
    {
        FireShot.Play();
    }

    public void RechargeSource()
    {
        Recharge.Play();
    }

}
