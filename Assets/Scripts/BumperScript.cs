﻿using UnityEngine;
using System.Linq;
using System.Collections;
using Assets.Scripts;
using System;

public class BumperScript : MonoBehaviour, IButtonPress {

    public float Power;
    public bool OverCharge;

    private Rigidbody2D _rb;
    private Sprite _currentSprite;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody2D>();
        _currentSprite = GetComponent<Sprite>();
	}

    void FixedUpdate() {

    }
    
    void OnCollisionEnter2D(Collision2D other) {
        Rigidbody2D playerBody = other.gameObject.GetComponent<Rigidbody2D>();
        // We need to get the contact points -centre of bumper
        var pointOfContact = other.contacts.FirstOrDefault();
        Vector2 launchTragectory = (OverCharge) 
            ? pointOfContact.normal.normalized * -(Power *3)
            : pointOfContact.normal.normalized * -Power;
        playerBody.AddForce(launchTragectory);
    }

    public virtual bool Trigger() {
        this.OverCharge = !this.OverCharge;
        return true;
    }

    public virtual bool UnTrigger() {
        this.OverCharge = !this.OverCharge;
        return true;
    }
}
