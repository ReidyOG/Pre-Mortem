using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton01_Attack : MonoBehaviour
{
    public static GameObject playerHit;
    private AudioSource mySource;
    private AudioClip hitClip;
    private float attackRate = 3;
    private float nextAttack;
    //private int damage = 10;
    private float minDistance = 5;
    private float currentDistance;
    private Transform myTransform;
    private skeleton01_Target targetScript;

    private Animator anim;


    // Use this for initialization
    void Start()
    {
        playerHit = GameObject.Find("Player");
        mySource = playerHit.GetComponent<AudioSource>();
        hitClip = playerHit.GetComponent<AudioClip>();
        anim = GetComponent<Animator>();

        myTransform = transform;
        targetScript = GetComponent<skeleton01_Target>();

        StartCoroutine(Attack());


    }

    void CheckIfTargetInRange()
    {
        if (targetScript.targetTransform != null)
        {
            currentDistance = Vector3.Distance(targetScript.targetTransform.position, myTransform.position);

            if (currentDistance < minDistance && Time.time > nextAttack)
            {
                mySource.Play();
                anim.SetBool("isIdle", false);
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", true);

                nextAttack = Time.time + attackRate;

            }
        }
    }

    IEnumerator Attack()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(0.2f);
            CheckIfTargetInRange();
        }
    }

}
