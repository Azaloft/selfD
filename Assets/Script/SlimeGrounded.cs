using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeGrounded : MonoBehaviour
{
    NavMeshAgent nav;
    void Start()
    {
        nav = GetComponentInParent<NavMeshAgent>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (nav.enabled == false)
        {
            this.enabled = false;
        }
        nav.isStopped = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (nav.enabled == false)
        {
            this.enabled = false;
        }
        nav.isStopped = false;
    }
}
