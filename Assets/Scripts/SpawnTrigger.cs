using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public int round;
    public float waitTime = 3;
    public GameObject enemy, enemyBox;

    private bool isTrigger, active;
    private int count;
    private float timer;
    private MonsterBloodManager bloodManager;

    private void Awake()
    {
        bloodManager = transform.parent.GetComponent<MonsterBloodManager>();
    }

    private void Start()
    {
        isTrigger = false;
        active = true;
        count = 0;
        timer = 0;
    }

    private void Update()
    {
        if (isTrigger)
        {
            timer += Time.deltaTime;
        }

        if(timer >= waitTime && count < round)
        {
            print("spawn time");
            timer = 0;
            count++;
            Spawn();
        }
    }

    private void Spawn()
    {
        if(count == round)
        {
            Invoke("CountSpawn", 1f);
        }

        //print("spawn");
        foreach (Transform sp in spawnPoints)
        {
            GameObject en = Instantiate(enemy);
            en.SetActive(true);
            en.transform.parent = enemyBox.transform;
            en.transform.position = new Vector3(sp.position.x, 0.1f, sp.position.z);

            //print(en.transform.position);
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

    private void CountSpawn()
    {
        bloodManager.spawn += 1;
        print(bloodManager.spawn);
    }
}
