using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    private Spawner spawner;

    public AudioSource audioSource;
    public AudioClip shot;

    public GameObject blue;
    public GameObject red;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {  
            audioSource.PlayOneShot(shot);

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("blue"))
                {
                    //faceade
                    hit.collider.gameObject.GetComponent<blue>().Collect();
                }
                if (hit.collider.gameObject.CompareTag("red"))
                {
                    //facede
                    hit.collider.gameObject.GetComponent<red>().Explode(); 
                }
            }
                
        }
    }
}
