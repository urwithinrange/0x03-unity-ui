using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 4000f;
	public Rigidbody rb;
	private int score = 0;
	public int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
	{
		if (Input.GetKey("a"))
		{
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
		}
        if (Input.GetKey("d"))
        {
			rb.AddForce(speed * Time.deltaTime, 0, 0);
		}
        if (Input.GetKey("w"))
		{
			rb.AddForce(0, 0, speed * Time.deltaTime);
		}
        if (Input.GetKey("s"))
        {
		    rb.AddForce(0, 0, -speed * Time.deltaTime);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Collider>().tag == "Pickup")
        {
            score++;
            Debug.Log($"Score: {score}");
            Object.Destroy(other.gameObject);
        }

        if (other.GetComponent<Collider>().tag == "Trap")
        {
            health--;
            Debug.Log($"Health: {health}");
        }

        if (other.GetComponent<Collider>().tag == "Goal")
        {
            Debug.Log("You Win!");
        }
	}
}
