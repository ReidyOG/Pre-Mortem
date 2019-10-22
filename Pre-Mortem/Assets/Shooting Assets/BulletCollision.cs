using UnityEngine;

namespace Shooting_Assets
{
    public class BulletCollision : MonoBehaviour
    {
        public static GameObject hitObject;
        private AudioSource mySource;

        // onTrigger is called when its collider hits another collider
        private void OnTriggerEnter(Collider collider)
        {
            hitObject = collider.gameObject;
            mySource = hitObject.GetComponent<AudioSource>();
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
