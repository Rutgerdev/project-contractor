﻿using UnityEngine;
using System.Collections;

public class PickableScript : MonoBehaviour {

    bool InRange = false;
    bool IsCarried = false;
    public bool clickable = true;

    GameObject player;
    PlayerScript playerScript;

    Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        player = GameManager.Instance.Player;
        playerScript = GameManager.Instance.PlayerScript;
        rigidBody = this.GetComponent<Rigidbody>();
	}

    public void PickUp() {
        if (playerScript.carriedValve == null) {
            this.transform.position = player.transform.position - player.transform.forward;
            this.transform.SetParent(player.transform);
            rigidBody.useGravity = false;
            rigidBody.isKinematic = true;
            IsCarried = true;
            rigidBody.constraints = RigidbodyConstraints.None;

            if (this.CompareTag("Valve")) {
                playerScript.carriedValve = this.gameObject;
            }
        }
    }

    public void OnCustomEvent() {
        if (clickable) {
            if (IsCarried) { Drop(); }
            else {
                if (InRange) { PickUp(); }
                else {
                    GameManager.Instance.Player.GetComponent<NavMeshAgent>().SetDestination(this.transform.position);
                    GameManager.Instance.ClickedObject = this.gameObject;
                    print(GameManager.Instance.ClickedObject.name);
                }
            }
        }
    }

    void Drop() {
        this.transform.parent = null;
        rigidBody.useGravity = true;
        rigidBody.isKinematic = false;
        IsCarried = false;

        if (this.CompareTag("Valve")) {
            playerScript.carriedValve = null;
        }
    }

    void RemoveClickedObject() {
        GameManager.Instance.ClickedObject = null;
    }

    public void Place(Vector3 position, GameObject parent) {
        this.transform.position = position;
        this.transform.SetParent(parent.transform);

        rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        rigidBody.useGravity = true;
        rigidBody.isKinematic = false;
        IsCarried = false;

        if (this.CompareTag("Valve")) {
            playerScript.carriedValve = null;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            InRange = true;
            if (GameManager.Instance.ClickedObject == this.gameObject) {
                PickUp();
                RemoveClickedObject();
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            InRange = false;
        }
    }
}
