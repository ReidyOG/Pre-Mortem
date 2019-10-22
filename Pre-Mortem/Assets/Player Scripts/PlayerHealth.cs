using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Player_Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        public int health = 3;
        private bool collisionOccuring = false;

        // Health UI
        public GameObject HP1;
        public GameObject HP2;
        public GameObject HP3;
        public Sprite REDHEART;
        public Sprite GRAYHEART;
        public GameObject DeathScreen;
        public Color SHOW = Color.red;

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

        private void HealthUI()
        {
            SHOW.a = 1;
            switch (health)
            {
                case 3:
                    HP1.GetComponent<Image>().sprite = REDHEART;
                    HP2.GetComponent<Image>().sprite = REDHEART;
                    HP3.GetComponent<Image>().sprite = REDHEART;
                    break;
                case 2:
                    HP1.GetComponent<Image>().sprite = REDHEART;
                    HP2.GetComponent<Image>().sprite = REDHEART;
                    HP3.GetComponent<Image>().sprite = GRAYHEART;
                    break;
                case 1:
                    HP1.GetComponent<Image>().sprite = REDHEART;
                    HP2.GetComponent<Image>().sprite = GRAYHEART;
                    HP3.GetComponent<Image>().sprite = GRAYHEART;
                    break;
                case 0:
                    HP1.GetComponent<Image>().sprite = GRAYHEART;
                    HP2.GetComponent<Image>().sprite = GRAYHEART;
                    HP3.GetComponent<Image>().sprite = GRAYHEART;
                    DeathScreen.GetComponent<Text>().color = SHOW;
                    StartCoroutine(Death());
                    UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                    break;
                default:
                    UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                    break;
            }
        }

        IEnumerator Death()
        {
            yield return new WaitForSecondsRealtime(5);
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
                HealthUI();
                mySource.Play();
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
