using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent agent;
    private Animator anim;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        agent = transform.GetComponent<NavMeshAgent>();
        anim = transform.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetBool("Attack"))
        {
            agent.destination = target.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            anim.SetBool("Attack", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            anim.SetBool("Attack", false);
        }
    }
}

