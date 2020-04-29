using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public float force;
    public NavMeshAgent nav;
    Animator anim;
    Rigidbody rb;
    Transform target;
    public float minDistance;
    Score Score;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (Vector3.Distance(transform.position, target.position) > 1.0f)
        {
            nav.destination = target.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(nav.pathPending == true)
        {

        }
        if (nav.enabled == false)
        {
            Vector3 direction = transform.position - target.transform.position;
            direction.Normalize();
            if(anim != null)
            {
                anim.enabled = false;
            }
            rb.velocity = direction * force;
        }
        if(nav.remainingDistance != Mathf.Infinity && nav.pathStatus == NavMeshPathStatus.PathComplete && nav.remainingDistance <= minDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        Score.score += distance;
    }

    public void KnockBack()
    {
        nav.enabled = false;
    }
}
