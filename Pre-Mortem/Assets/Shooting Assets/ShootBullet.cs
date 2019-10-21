using System;
using UnityEngine;

namespace Shooting_Assets
{
    public class ShootBullet : MonoBehaviour
    {
        public GameObject projectile;
        public float speed;
        public float despawn;
        // Start is called before the first frame update
//        void Start()
//        {
//        
//        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject gun = GameObject.FindWithTag("Gun");
                GameObject cam = GameObject.FindWithTag("MainCamera");
                Vector3 front = gun.transform.position;
                Debug.Log(front.ToString());
                GameObject bullet = Instantiate(projectile, front, gun.transform.rotation);
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                bulletRigidbody.velocity = transform.TransformDirection(0, 0, speed);
                Destroy(bullet, despawn);
            }
        }
    }
}
