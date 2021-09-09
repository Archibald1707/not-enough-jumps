using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeScript : MonoBehaviour
{
	public float fieldOfImpact;
	public float force;
	
	public GameObject explosionEffect;
	
	public LayerMask LayerToHit;
	
	void explode()
	{
		Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, LayerToHit);
		
		foreach(Collider2D obj in objects)
		{
			Vector2 direction = obj.transform.position - transform.position;
			
			obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
		}
		
		GameObject explosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
		
		Destroy(explosionEffectIns, 3);
	}
	
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
	}
	
    void OnCollisionEnter2D(Collision2D collision)
	{
		explode();
		Destroy(gameObject);
	}
}
