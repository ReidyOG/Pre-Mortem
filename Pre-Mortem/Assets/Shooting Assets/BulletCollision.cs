using UnityEngine;

namespace Shooting_Assets
{
    public class BulletCollision : MonoBehaviour
    {
        public static GameObject hitObject;
        private AudioSource mySource;

        private void Start()
        {
            hitObject = GameObject.Find("Skeleton");
            mySource = hitObject.GetComponent<AudioSource>();
        }
        // onTrigger is called when its collider hits another collider
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag.Equals("enemy"))
            {
                mySource.Play();
                GameObject enemy = collider.gameObject;
                Animator enemyAnimator = enemy.GetComponent<Animator>();
                enemyAnimator.SetTrigger("isDamaged");
                Destroy(gameObject);
            }
        }
    }
}
