using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
	public int points;
	public int jumpCounter;
	public float power = 10f;
	public Rigidbody2D rb;
	
	public Vector2 minPower;
	public Vector2 maxPower;
	
	TrajectoryLine tl;
	
	Camera cam;
	Vector2 force;
	Vector3 startPoint;
	Vector3 endPoint;
	
	public GameManager gameManager;
	//public GameObject menu;
	
	private void Start()
	{
		//menu = GameObject.Find("little_menu");
		//if(menu != null)
		//	menu.SetActive(false);
		cam = Camera.main;
		tl = GetComponent<TrajectoryLine>();
	}
	
	private void Update()
	{
		if (jumpCounter > 0){
		if (Input.GetMouseButtonDown(0))
		{
			startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
			startPoint.z = 15;
		}
		
		if (Input.GetMouseButton(0))
		{
			Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
			currentPoint.z = 15;
			tl.RenderLine(startPoint, currentPoint);
		}
		
		if (Input.GetMouseButtonUp(0))
		{
			endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
			endPoint.z = 15;
			
			force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
			rb.AddForce(force * power, ForceMode2D.Impulse);
			tl.EndLine();
			jumpCounter--;
		}
		}
		else
		{
			FindObjectOfType<GameManager>().EndGame();
		}
	}
}
