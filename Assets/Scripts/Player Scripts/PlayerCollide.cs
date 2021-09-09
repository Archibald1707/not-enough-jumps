using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
	public DragNShoot counter;
	
	public GameObject collisionEffect;
	
	public GameObject levelCompleteUI;
	
	private Rigidbody2D rb;
	
	Vector3 lastVelocity;
	
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update()
	{
		lastVelocity = rb.velocity;
	}
	
    private void OnCollisionEnter2D(Collision2D collisionObject)
	{
		if (collisionObject.collider.tag == "obstacle")
		{
			var speed = lastVelocity.magnitude;
			var direction = Vector3.Reflect(lastVelocity.normalized, collisionObject.contacts[0].normal);
			
			rb.velocity = direction * Mathf.Max(speed*2/3, 0f);
			
			GameObject collisionEffectIns = Instantiate(collisionEffect, transform.position, Quaternion.identity);
			Destroy(collisionEffectIns, 2);
		}
		else if (collisionObject.gameObject.tag == "gem")
		{
			counter.points+=5;
			counter.jumpCounter+=3;
		}
		else if (collisionObject.gameObject.tag == "emerald")
		{
			counter.points++;
			counter.jumpCounter+=2;
		}
		else
		{
			//under construction
		}
	}
	
	void OnTriggerEnter2D(Collider2D trigger)
	{
		rb.constraints = RigidbodyConstraints2D.FreezeAll;
		levelCompleteUI.SetActive(true);
	}
}
