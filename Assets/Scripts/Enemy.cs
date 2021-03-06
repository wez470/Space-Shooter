﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float Speed;

    private Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	void FixedUpdate() {
        transform.up = player.position - transform.position;
        GetComponent<Rigidbody2D>().velocity = transform.up * Speed;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player") {
            GameController.Instance.GameOver();
            Time.timeScale = 0;
        }
    }
}
