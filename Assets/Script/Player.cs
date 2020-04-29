using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.VR.EventSystems;

public class Player : MonoBehaviour
{
    public float speedRate = 100f;
    public float rotationRate = 100f;
    Camera cam;
    // Update is called once per frame
    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        float rotation = Input.GetAxis("Horizontal") * rotationRate * Time.deltaTime;
        float upDown = Input.GetAxis("Vertical") * speedRate * Time.deltaTime;
        transform.Rotate(upDown, rotation, 0);
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            Debug.DrawRay(cam.transform.position, cam.transform.forward);
            Enemy en = hit.transform.GetComponent<Enemy>();
            if(en != null)
            {
                en.KnockBack();
            }
        }
    }
}
