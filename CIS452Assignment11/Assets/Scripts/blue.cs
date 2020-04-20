/*
 * Matt Kirchoff
 * blue.cs
 * CIS 452 Assignment 10
 * this returns the object to pool when run into the drain
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blue : MonoBehaviour
{
    private ObjectPooler objectPooler;
    private Spawner spawner;
    private AudioSource audioSource;

    public AudioClip collect;
    public AudioClip meh;


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
        if(other.CompareTag("Drain"))
        {
            int temp = spawner.score;
            spawner.score = temp + 1;
            audioSource.PlayOneShot(collect);
            objectPooler.ReturnObjectToPool("blue", this.gameObject);
        }
    }
    public void Collect()
    {
        audioSource.PlayOneShot(meh);
        objectPooler.ReturnObjectToPool("blue", this.gameObject);
        
    }
   
}
