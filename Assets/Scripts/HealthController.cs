using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

    [Tooltip("Vida total")]
    public int maxHP;
    [Tooltip("Vida actual")]
    public int actualHP;
    public RectTransform hearthUI;
    private float heartSize = 25.28615f;

    // Start is called before the first frame update
    void Start() {
       actualHP = maxHP; 
    }

    // Update is called once per frame
    void Update() {  
        
    }
    // Function DoDamage: -1 HP and destroy of gameObject if die (HP == 0)
    public void DoDamage() {
        --actualHP;
        if (actualHP < 0) {
            actualHP = 0;
        }
        if (actualHP <= 0) {
            //HealthContainer.instance.DestroyHearth();
            if (gameObject.tag != "Player") {
                // Only enemies
                Destroy(gameObject);
            } 
            if (gameObject.tag == "Player") {
               hearthUI.sizeDelta = new Vector2(heartSize * actualHP, heartSize);
            }
        }
    }
}
