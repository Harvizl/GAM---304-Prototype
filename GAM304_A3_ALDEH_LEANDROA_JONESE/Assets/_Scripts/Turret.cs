using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Vector3 target;
    public Transform plane;
    public GameObject projectileGO;

    public int shotCoolDown = 1;

    public bool lockedOn;

    public float xPos;
    public float yPos;
    public float zPos;
    public float speed = 10f;

    // Use this for initialization
    void Start()
    {
        plane = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()

    {
        xPos = plane.position.x;
        yPos = plane.position.y;
        zPos = plane.position.z;
        target = plane.position;
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == null)
        {
            //do an idle animation
        }

        if (other.tag == "Player")
        {
            transform.LookAt(plane);
            if (shotCoolDown == 1)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.LookAt(plane);
            CancelInvoke("Fire");

        }
    }

    IEnumerator Shoot()
    {
        shotCoolDown--;
        Vector3 origin;
        Vector3 destination;

        origin = projectileGO.transform.position;
        destination = plane.position;
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 150f);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 150f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            GameObject projectile = Instantiate(projectileGO, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody>().velocity = (hit.point - transform.position).normalized * 35f;
            yield return new WaitForSeconds(1);
            shotCoolDown++;
        }
    }
}
