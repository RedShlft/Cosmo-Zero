﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Radar : MonoBehaviour
{
    [SerializeField]
    private Transform radar_center;
    [SerializeField]
    private float radius_radar = 20F;
    [SerializeField]
    private GameObject blip;
    private Transform disc;
    public GameObject player;
    public GameObject mimick;

    private List<Transform> list_radar;
    private List<Transform> list_actual;

    private double x, y, z;

    void Start ()
    {
        list_radar = new List<Transform>();
        list_actual = new List<Transform>();
        disc = transform.transform.Find("disc");
        list_actual.Add(player.transform);
        Vector3 radar_pos = transform.position + (player.transform.position - radar_center.position) * transform.localScale.x / radius_radar;
        GameObject new_obj = Instantiate(blip, radar_pos, disc.rotation) as GameObject;
        new_obj.transform.parent = gameObject.transform;
        list_radar.Add(new_obj.transform);
    }
	
	void Update ()
	{
        mimick.transform.position = player.transform.position;
        mimick.transform.rotation = player.transform.rotation;
	    transform.localRotation = radar_center.rotation;
	    int layerMask = 1 << 8; //Layer 8
        Collider[] insideRadar = Physics.OverlapSphere(radar_center.position,radius_radar,layerMask);

	    foreach (Collider collider1 in insideRadar) //add new objects in the radar
	    {
	        bool add = true;
	        int counter = 0;
            if (collider1.CompareTag("Player"))
                add = false;
	        while (counter < list_actual.Count && add) //Test if collider is already in the radar
	        {
	            if (list_actual[counter].name == collider1.name) //maybe find another unique property
	            {
                    add = false;
	            }
	            counter++;
	        }

	        if (add) //if it is not, adds it
	        {
                Vector3 radar_pos = transform.position + (collider1.transform.position - radar_center.position) * transform.localScale.x / radius_radar;
                
                GameObject new_obj= Instantiate(blip, radar_pos, disc.rotation) as GameObject;
	            new_obj.transform.parent = gameObject.transform;

                
                list_actual.Add(collider1.transform);
                list_radar.Add(new_obj.transform);
            }
	    }
        

	    for (int i = 0; i < list_radar.Count; i++) //Checks if all the objects in the radar are still i the radar
	    {
	        if ((list_actual[i].position - radar_center.position).magnitude > radius_radar)
	        {
	            Destroy(list_radar[i].gameObject); //Destroy the blip if no more in the radar
	            list_actual.RemoveAt(i);
	            list_radar.RemoveAt(i);
            }
        }
	    for (int i = 0; i < list_radar.Count; i++) //updates the elements in the radar
	    {
	        list_radar[i].localPosition = (list_actual[i].position - radar_center.position) * transform.localScale.x / radius_radar;
	        //list_radar[i].localRotation = radar_center.rotation;
	        //radar_center.TransformPoint(list_actual[i].localPosition) * transform.localScale.x/radius_radar; //FIXME
	        // //* transform.localScale.x is used to put in the radar sphere
	    }

    }
}
