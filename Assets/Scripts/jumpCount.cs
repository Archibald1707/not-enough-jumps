using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jumpCount : MonoBehaviour
{
    public DragNShoot player;
	public Text jumpText;
	

    void Update()
    {
        jumpText.text = player.jumpCounter.ToString();
    }
}
