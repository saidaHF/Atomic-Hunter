using UnityEngine;
using System.Collections;

public class CharacterShootings : MonoBehaviour
{
    [SerializeField] // for view in inspector
    private Transform bulletSpawner;
    [SerializeField]
    private LineRenderer hitLine;
    [SerializeField]
    private bool raycastShooting = true;
    void Update() {   // Detects clicks from the mouse:

        // Pabsorb - SHOOT
        if (Input.GetMouseButtonDown(0)) {

            if(raycastShooting) 
            StartCoroutine(Raycast_Shooting());
        }
        // Pabsorb - ABSORB
        if (Input.GetMouseButtonDown(1))
        Debug.Log("Pressed secondary button ABSORB");
    }

    IEnumerator Raycast_Shooting() {
        RaycastHit2D hit = Physics2D.Raycast(bulletSpawner.position, bulletSpawner.right);

        if (hit) {
            // Search the enemies:
            Enemies_Controller enemies = hit.transform.GetComponent<Enemies_Controller>();
            
            if(enemies != null) {
                enemies.Attacked(); // Damage, when shoot to collide with enemies, -1 HP
                hitLine.SetPosition(0, bulletSpawner.position);
                hitLine.SetPosition(1, hit.point);
            }
        } else {
            // if it does not collide with anything, size 100 (You can convert 100 into a variable to modify it)
            hitLine.SetPosition(0, bulletSpawner.position);
            hitLine.SetPosition(1, bulletSpawner.position + bulletSpawner.right * 100);
        }

        hitLine.enabled = true;
        yield return new WaitForSeconds(0.02f); // For fade the line in 0,02 seconds
        hitLine.enabled = false;
    }
}
