﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour {

    public GameObject jumpscareObject;
    public float wait = 1.5f;

    void Start () {

        jumpscareObject.SetActive(false);
	}
	
	void OnTriggerEnter (Collider player) {
        if(player.tag == "Player")
        {
            jumpscareObject.SetActive(true);
            StartCoroutine(DestroyObject());
        }		
	}
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(wait);
        Destroy(jumpscareObject);
        Destroy(gameObject);
    }
}