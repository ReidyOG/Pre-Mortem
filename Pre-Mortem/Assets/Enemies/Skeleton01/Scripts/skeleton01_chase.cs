using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class skeleton01_chase : MonoBehaviour
{
    //public Transform player;
    [SerializeField]
    private Animator anim;
    //public Slider healthbar;
    [SerializeField]
    public string targetTag = "Player";
    private Transform target;
    //private GameObject target;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (healthbar.value <= 0) return;
        //if (targetTag != null)
        target = GameObject.FindWithTag(targetTag).transform;
        //target = GameObject.FindWithTag(targetTag);

        Vector3 direction = target.position - this.transform.position;
        //Vector3 direction = target.transform.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(target.position, this.transform.position) < 10 && angle < 60)
        //if (Vector3.Distance(target.transform.position, this.transform.position) < 10 && angle < 60)
        {

            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                        Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);
            if (direction.magnitude > 2)
            {
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }

        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }

    }
}
