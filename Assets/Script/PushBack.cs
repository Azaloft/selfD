using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PushBack : MonoBehaviour
{
    public float force;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enmey")
        {
            other.GetComponent<NavMeshAgent>().enabled = false;
            other.attachedRigidbody.AddForce(transform.forward * force);
        }
    }
}
