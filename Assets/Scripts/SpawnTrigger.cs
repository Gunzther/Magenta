using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public int round;
    public GameObject enemy, enemyBox;

    private bool isTrigger, active;
    private int count;
    private float timer;

    private void Start()
    {
        isTrigger = false;
        active = true;
        count = 0;
    }

    private void Update()
    {
        if(isTrigger) timer += Time.deltaTime;

        if(count < round && timer >= 3)
        {
            print("spawn time");
            timer = 0;
            Spawn();
            count++;
        }
    }

    private void Spawn()
    {
        print("spawn");
        foreach (Transform sp in spawnPoints)
        {
            GameObject en = Instantiate(enemy);
            en.transform.position = new Vector3(sp.position.x, 0.1f, sp.position.z);
            en.transform.parent = enemyBox.transform;

            print(en.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(active && other.transform.tag == "Player")
        {
            isTrigger = true;
            active = false;
            count++;
            Spawn();
        }
    }
}
