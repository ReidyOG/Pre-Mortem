﻿using System.Collections;
using UnityEngine;

namespace Player_Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        public int health = 3;
        private bool collisionOccuring = false;
        public AudioSource mySource;
    
        // On Trigger event
        private void OnTriggerEnter(Collider collider)
        {
            string collided = collider.gameObject.name;
            if (collided.Equals("Capsule") && !collisionOccuring)
            {
                StartCoroutine(Waiting(collider));
            }
            else
            {
                Debug.Log("Collided with: " + collided);
            }
        }

        IEnumerator Waiting(Collider collider)
        {
            AnimatorStateInfo skeleState = (collider.gameObject.GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0));
            bool swinging = (skeleState.normalizedTime > 0.35) && (skeleState.normalizedTime < 0.4);
            bool attacking = skeleState.IsName("Attack");
            if (attacking && swinging)
            {
                collisionOccuring = true;
                Debug.Log("Collided with " + collider.gameObject.name);
                health--;
                mySource.Play();
                Debug.Log(health);
                if (health == 0)
                {
                    Application.Quit();
                }
                Debug.Log("Unhittable");
                yield return new WaitForSeconds(1);
                collisionOccuring = false;
                Debug.Log("Hittable");
            }
        }
    }
}
