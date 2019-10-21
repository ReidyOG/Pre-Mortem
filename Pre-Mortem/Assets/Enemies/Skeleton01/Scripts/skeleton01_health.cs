using UnityEngine;

namespace Enemies.Skeleton01.Scripts
{
    public class skeleton01_health : MonoBehaviour
    {
        public int health = 3;
        public Animator skeleAnimator;

        private bool collided = false;
        // Start is called before the first frame update
//        void Start()
//        {
//            
//        }

        // Update is called once per frame
        void Update()
        {
            if (skeleAnimator.GetNextAnimatorStateInfo(0).IsName("Damage") && !collided)
            {
                health--;
                collided = true;
            } else if(!skeleAnimator.GetNextAnimatorStateInfo(0).IsName("Damage"))
            {
                collided = false;
            }
            if(health == 0)
            {
                skeleAnimator.SetTrigger("isDead");
                Destroy(gameObject, 3);
            }
        }
    }
}
