using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float xRnage = 10;
    public float horizontalInput;
    public float speed = 10.0f;
    private float topoBound = 30;
    private float lowerBound = -10;

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topoBound)
        {
            Destroy(gameObject); 
        } else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch projectile from player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        if (transform.position.x < -xRnage)
        {
            transform.position = new Vector3(-xRnage, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRnage)
        {
            transform.position = new Vector3(xRnage, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }
}
