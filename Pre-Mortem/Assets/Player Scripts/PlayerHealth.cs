using System.Collections;
using UnityEngine;

namespace Player_Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        public int health = 3;
        private bool collisionOccuring = false;
    
        // On Trigger event
        private void OnTriggerEnter(Collider collider)
        {
            string collided = collider.gameObject.name;
            if (collided.Equals("Capsule") && !collisionOccuring)
            {
                StartCoroutine(Waiting(collider));
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
                Debug.Log(health);
                if (health == 0)
                {
                    
                }
                Debug.Log("Unhittable");
                yield return new WaitForSeconds(1);
                collisionOccuring = false;
                Debug.Log("Hittable");
            }
        }
    }
}
