using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointCount : MonoBehaviour
{
    public DragNShoot player;
	public Text pointText;
	

    void Update()
    {
        pointText.text = player.points.ToString();
    }
}
