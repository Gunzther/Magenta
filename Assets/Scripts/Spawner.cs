using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obj;
    public List<GameObject> clones;
    public int amount;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < amount; i++)
        {
            GameObject gameObject = Instantiate(obj);
            gameObject.transform.position = new Vector3(0, i, 0);
            clones.Add(gameObject);
        }
        //foreach(GameObject clone in clones)
        //{
        //    clone.transform.parent = obj.transform;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
