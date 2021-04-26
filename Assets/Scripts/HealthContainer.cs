using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class HealthContainer : MonoBehaviour {

    public static HealthContainer instance { private set; get; }
    public GameObject hearth;
    public Vector2 initialPosition;

    public List<GameObject> hearths;


    private void Awake(){
        if (instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start(){
        int maxHP = CharacterController.Instance.health.maxHP;
        if (!hearth) return;
        Vector2 lastPosition = initialPosition; 
        for(int i = 0; i < maxHP; i++) {
            GameObject obj = Instantiate(hearth, lastPosition, Quaternion.identity, gameObject.transform);
            hearths.Add(obj);
            lastPosition = new Vector2(lastPosition.x + 32, lastPosition.y);
        }
    }
    
    public void DestroyHearth(){
        Debug.Log("ouch");
        Destroy(hearths.Last());
    }

    private void OnDestroy(){
        instance = null;
    }
}