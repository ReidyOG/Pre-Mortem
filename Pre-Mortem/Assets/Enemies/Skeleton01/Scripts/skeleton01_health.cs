using UnityEngine;

namespace Enemies.Skeleton01.Scripts
{
    public class skeleton01_health : MonoBehaviour
    {

        public RectTransform healthBar;

        public int health = 5;
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

            healthBar.sizeDelta = new Vector2(health * 40, healthBar.sizeDelta.y);

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
                Destroy(gameObject, 2);
            }
        }
    }
}
