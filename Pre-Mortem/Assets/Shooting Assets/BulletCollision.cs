using UnityEngine;

namespace Shooting_Assets
{
    public class BulletCollision : MonoBehaviour
    {
        // Start is called before the first frame update
//        void Start()
//        {
//        
//        }

        // Update is called once per frame
//        void Update()
//        {
//        
//        }
    
        // onTrigger is called when its collider hits another collider
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag.Equals("enemy"))
            {
                GameObject enemy = collider.gameObject;
                Animator enemyAnimator = enemy.GetComponent<Animator>();
                enemyAnimator.SetTrigger("isDamaged");
                Destroy(gameObject);
            }
        }
    }
}
