﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bossScript : MonoBehaviour
{
    public float shipSpeed = 0.1F;
    public float shipSpeed2 = 20;
    public float dist1 = 1000;
    public float curDist = 0;
    public float time1 = 500;
    public bossQuest bQ;
    public Text boss;
	void Start () {
	
	}
	
	void Update ()
	{
	    int percent = (int)(curDist / 10);
        boss.text = "Boss progression " + percent.ToString() + "%";



	    if (curDist <= dist1)
	    {
	        transform.position = transform.position + transform.forward * shipSpeed;
	        curDist += shipSpeed;
        }
	    else if (curDist <= dist1 + time1 )
	    {
	        curDist += shipSpeed;
	    }
        else
	    {
	        transform.position = transform.position + transform.forward * shipSpeed2;
            curDist += shipSpeed2;
	        if (curDist > time1 + dist1 + 1000)
	        {
	            bQ.lost = true;
	            Destroy(gameObject);
	        }
	    }
	    
	}
}
