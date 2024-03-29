﻿using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class CharacterShootings : MonoBehaviour
{
    [SerializeField] // for view in inspector
    private Transform bulletSpawner;
    [SerializeField]
    private LineRenderer hitLine;
    [SerializeField]
    private bool raycastShooting = true;
    public GameController gameController;
    public AudioSource laser;

    void Update() {   // Detects clicks from the mouse:
        if (!gameController.paused) {
            // Pabsorb - SHOOT
            if (Input.GetMouseButtonDown(0)) {
                   laser.Play();
                if (raycastShooting) {
                    StartCoroutine(RaycastShooting());
                }
            }
            // Pabsorb - ABSORB
            if (Input.GetMouseButtonDown(1))
            Debug.Log("Pressed secondary button: ABSORB");
        }
    }

    IEnumerator RaycastShooting() {
        RaycastHit2D hit = Physics2D.Raycast(bulletSpawner.position, bulletSpawner.right);

        if (hit) {
            // Search the colliders with damaged:
            HealthController healthController = hit.transform.GetComponent<HealthController>();
            
            if (healthController) {
                healthController.DoDamage(); // Damage, when shoot to collide with enemies, -1 HP
                hitLine.SetPosition(0, bulletSpawner.position);
                hitLine.SetPosition(1, hit.point);
            } else { // collider with object (!healthController)
                hitLine.SetPosition(0, bulletSpawner.position);
                hitLine.SetPosition(1, hit.point);
            }
            
        } else {
            // if it does not collide with anything, size 50 (You can convert 100 into a variable to modify it)
            hitLine.SetPosition(0, bulletSpawner.position);
            hitLine.SetPosition(1, bulletSpawner.position + bulletSpawner.right * 50);
        }

        hitLine.enabled = true;
        yield return new WaitForSeconds(0.02f); // For fade the line in 0,02 seconds
        hitLine.enabled = false;
    }
}
