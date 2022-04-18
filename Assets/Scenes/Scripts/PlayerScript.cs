using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int health ;
    //int maxHealth = 100;
  //public bool isDead = false;
   // public GameObject enemy;
   // public float playerSpeed;
    Rigidbody rb;
  //  public float rotationSpeed;*/
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
       // transform.Rotate(0, Input.GetAxis("Mouse Y")*rotationSpeed, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            Debug.Log("Coin Collected");
            Destroy(other.gameObject);
        }
    }
}
