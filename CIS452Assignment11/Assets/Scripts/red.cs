/*
 * Matt Kirchoff
 * red.cs
 * CIS 452 Assignment 10
 * this returns the object to pool when run into the drain
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red : MonoBehaviour
{
    private ObjectPooler objectPooler;
    private Spawner spawner;
    private AudioSource audioSource;
    public AudioClip explode;
    public AudioClip drain;

    public float radius;
    public float power;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        objectPooler = FindObjectOfType<ObjectPooler>();
        spawner = FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drain"))
        {
            audioSource.PlayOneShot(drain);
            int temp = spawner.score;
            spawner.score = temp - 1;
            objectPooler.ReturnObjectToPool("red", this.gameObject);
        }
    }
    public void Explode()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        Vector3 target = rb.gameObject.transform.position;
        Collider[] colliders = Physics.OverlapSphere(target, radius);
        foreach (Collider col in colliders)
        {
            Rigidbody rb2 = col.GetComponent<Rigidbody>();
            if (rb2 != null)
            {
                rb2.AddExplosionForce(power, rb2.gameObject.transform.position, radius, 3.0f, ForceMode.Impulse);
            }
        }
        target = target + new Vector3(0, -2.5f, 0);
        rb.AddExplosionForce(power / 2, rb.gameObject.transform.position, radius, 3.0f, ForceMode.Impulse);
        audioSource.PlayOneShot(explode);
    }
}
