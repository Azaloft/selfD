using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WispSpawn : MonoBehaviour
{
    public ParticleSystem ps;
    public Color pscolour;
    public float rate;
    public Transform wisp;
    NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        nav = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        pscolour = Color.Lerp(Color.white, Color.cyan, Time.time/rate);
        var main = ps.main;
        main.startColor = pscolour;
        if (ps.isStopped)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        nav.isStopped = false;
    }
}
