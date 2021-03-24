using UnityEngine;
using System.Collections;

// Detects clicks from the mouse and prints a message

public class CharacterShootings : MonoBehaviour
{
    [SerializeField]
    private Transform bulletSpawner;

    [SerializeField]
    private LineRenderer hitLine;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(Raycast_Shooting());

        if (Input.GetMouseButtonDown(1))
            Debug.Log("Pressed secondary button.");
    }

    IEnumerator Raycast_Shooting() {
        RaycastHit2D hit = Physics2D.Raycast(bulletSpawner.position, bulletSpawner.right);

        if(hit) {
            // Search the enemies:
            Enemies_Controller enemies = hit.transform.GetComponent<Enemies_Controller>();
            
            if(enemies != null) {
                // Damage = daño, when shoot to collide with enemies, -1 HP
             // FALTA CREAR " enemies.TakeDamage(1); " en Enemies_Controller, esto resta 1 HP de vida al enemigo en cada golpe
               // para ver hasta donde choca:
                hitLine.SetPosition(0, bulletSpawner.position);
                hitLine.SetPosition(1, hit.point);
            } else {
                // si no choca con nada un tamaño de 100 maximo, se puede convertir en variable este 100 para modificarlo
                hitLine.SetPosition(0, bulletSpawner.position);
                hitLine.SetPosition(1, bulletSpawner.position + bulletSpawner.right * 100);
            }

            hitLine.enabled = true;
            yield return new WaitForSeconds(0.02f); // For fade the line in 0,02 seconds
            hitLine.enabled = false;
        }
    }
}
