using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1 : MonoBehaviour
{

     public float nextTimeToFire = 0f;
    public float damage =10f;
    public float range = 100f;
    public float force = 20f;
    public float fireRate = 10f;


    public Camera fpsCam;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }


    void Shoot ()
        {
        /*shootSound.Play();*/
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            target target = hit.transform.GetComponent<target>();
            if (target!=null)
            {
                target.TakeDamage(damage);
                
            }
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
            }
        }
    }
}
