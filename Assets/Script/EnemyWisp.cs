using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWisp : MonoBehaviour
{
    public Transform target;
    NavMeshAgent nav;
    Renderer mes;
    Material mat;
    public float fly;
    public float rate;
    public float ratecolor;
    public float heightMin;
    public float heightMax;
    public float waitTime;
    bool waitover;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponentInParent<NavMeshAgent>();
        mes = GetComponent<MeshRenderer>();
        mat = mes.material;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        nav.isStopped = true;
        float height = Random.Range(heightMin, heightMax);
        transform.position = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
        if (nav.isStopped == false)
        {
        }
        if(transform.position.y != target.transform.position.y + fly)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, target.transform.position.y + fly, transform.position.z), rate);
        }
        if(waitover == true)
        {
            mes.material.color = Color.Lerp(new Color(0.5058824f, 1, 1, 0), new Color(0.5058824f, 1, 1, 0.3f), ratecolor);
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(waitTime);
        waitover = true;
    }
}
