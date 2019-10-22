using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int timer = 0, level = 0, spawnDelay = 1; // In-game time
    public GameObject enemy;    //The enemy object prefab
    public GameObject spawner1, spawner2, spawner3;
    private GameObject[] numberOfEnemies;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Instantiate(enemy, spawner1.transform.position, spawner1.transform.rotation); // Beginning enemy
        //Instantiate(enemy, spawner1.transform.position, spawner1.transform.rotation);

    }
    // Update is called once per frame
    void Update()
    {
        timer++;
        
        if (timer%50 == 0)//(Input.GetKeyDown(KeyCode.Pipe)||Input.GetKeyDown(KeyCode.Space))
        {
            //print("Test");
            //numberOfEnemies = GameObject.FindGameObjectsWithTag("enemy");
            if (!GameObject.FindWithTag("enemy"))
            {// can't find object  with enemy tag
                level++;
                for (int i = 0; i < level; i++)
                {
                    Instantiate(enemy, spawner1.transform.position, spawner1.transform.rotation);
                    Instantiate(enemy, spawner2.transform.position, spawner2.transform.rotation);
                    Instantiate(enemy, spawner3.transform.position, spawner3.transform.rotation);
                    IEnumerator Delay()
                    {
                        yield return new WaitForSeconds(spawnDelay);
                    }
                }
            }
        }
        
    }
}
