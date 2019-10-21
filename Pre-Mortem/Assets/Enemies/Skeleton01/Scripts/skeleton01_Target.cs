using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class skeleton01_Target : MonoBehaviour
{

    private NavMeshAgent agent;
    private Transform myTransform;
    public Transform targetTransform;
    private LayerMask raycastLayer;
    private float radius = 100;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        myTransform = transform;
        raycastLayer = 1 << LayerMask.NameToLayer("Player");
         
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SearchForTarget();
        MoveToTarget();
    }

    void SearchForTarget()
    {

        if (targetTransform == null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(myTransform.position, radius, raycastLayer);

            if (hitColliders.Length > 0)
            {
                int randomint = Random.Range(0, hitColliders.Length);
                targetTransform = hitColliders[randomint].transform;
            }
        }

        if (targetTransform != null && targetTransform.GetComponent<BoxCollider>().enabled == false)
        {
            targetTransform = null;
        }
    }

    void MoveToTarget()
    {
        if (targetTransform != null)
        {
            SetNavDestination(targetTransform);
        }
    }

    void SetNavDestination(Transform dest)
    {

        anim.SetBool("isIdle", false);
        anim.SetBool("isWalking", true);
        anim.SetBool("isAttacking", false);

        agent.SetDestination(dest.position);
    }

    IEnumerator DoCheck()
    {
        for (; ; )
        {
            SearchForTarget();
            MoveToTarget();
            yield return new WaitForSeconds(0.2f);
        }
    }

}
