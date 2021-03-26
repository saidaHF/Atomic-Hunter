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
    
        // Pabsorb shot
        if (Input.GetMouseButtonDown(0)) {

            if(raycastShooting) 
            StartCoroutine(Raycast_Shooting());
        }
        // Pabsorb absorb
        if (Input.GetMouseButtonDown(1))
        Debug.Log("Pressed secondary button ABSORB");
    }

    IEnumerator Raycast_Shooting() {
        RaycastHit2D hit = Physics2D.Raycast(bulletSpawner.position, bulletSpawner.right);

        if(hit) {
            // Search the enemies:
            Enemies_Controller enemies = hit.transform.GetComponent<Enemies_Controller>();
            
            if(enemies != null) {
                //enemies.TakeDamage(1);

                // Damage, when shoot to collide with enemies, -1 HP
                // FALTA CREAR en Enemies_Controller - - - esto resta 1 HP de vida al enemigo en cada golpe
                // para ver hasta donde choca:
                hitLine.SetPosition(0, bulletSpawner.position);
                hitLine.SetPosition(1, hit.point);
            } 

        } else {
                // if it does not collide with anything, size 50 (You can convert 50 into a variable to modify it)
                hitLine.SetPosition(0, bulletSpawner.position);
                hitLine.SetPosition(1, bulletSpawner.position + bulletSpawner.right * 50);
            }

            hitLine.enabled = true;
            yield return new WaitForSeconds(0.02f); // For fade the line in 0,02 seconds
            hitLine.enabled = false;
    }
}
