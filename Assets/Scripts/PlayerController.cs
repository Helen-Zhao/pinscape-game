﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float accl;
    public float maxSpeed;
    public float jumpStrength;
    public LayerMask[] jumpableLayers;

    private Rigidbody2D _rb;
    private EdgeCollider2D _feet;
    private float _moveX;
    private float _moveY;
    private bool _canJump;
    private Vector2 _jump;

    // Use this for initialization
    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _feet = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        this.movementManager();
        this.reset();
    }

    // Helper method that deals with movement.
    private void movementManager() {
        // Check if we need to do player 1 or player 2 controls
        if (gameObject.tag == "Player") {
            // Horizontal movement
            Vector2 forceX = Vector2.zero;
            if (Input.GetKey(KeyCode.RightArrow)) {
                forceX = new Vector2(1, 0f);
            } else if (Input.GetKey(KeyCode.LeftArrow)) {
                forceX = new Vector2(-1, 0f);
            }
            if (Mathf.Abs(_rb.velocity.x) <= maxSpeed) {
                _rb.AddForce(forceX * accl);
            }
            if (isGrounded()) {
				if (Input.GetKey(KeyCode.UpArrow)) {
                    _jump = new Vector2(0f, jumpStrength);
                    _rb.AddForce(_jump, ForceMode2D.Impulse);
                }
            }
        } else if(gameObject.tag == "Player2") {
            // Player 2 keys
            Vector2 forceX = Vector2.zero;
            if (Input.GetKey(KeyCode.D)) {
                forceX = new Vector2(1, 0f);
            } else if (Input.GetKey(KeyCode.A)) {
                forceX = new Vector2(-1, 0f);
            }
            if (Mathf.Abs(_rb.velocity.x) <= maxSpeed) {
                _rb.AddForce(forceX * accl);
            }
            if (isGrounded()) {
                if (Input.GetKey(KeyCode.W)) {
                    Vector2 jump = new Vector2(0f, jumpStrength);
                    _rb.AddForce(jump, ForceMode2D.Impulse);
                }
            }
        }

        //moveX = (Mathf.Abs(rb.velocity.x) >= maxSpeed) ? 0 : Input.GetAxis("Horizontal");
        //Vector2 forceX = new Vector2(moveX, 0f);
        
        // Horizontal movement to player object

    }

    #region Helper methods
    // Resets values after processing
    private void reset() {

    }

    private bool isGrounded() {
        // If its not in the jumping
        if (_rb.velocity.y <= 0) {
            foreach (LayerMask lm in jumpableLayers) {
				if (_feet.IsTouchingLayers (lm)) {
					return true;
				}
            }
        }
        return false;
    }
    #endregion
}