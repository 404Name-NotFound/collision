using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    
    public GameObject obj;

    public float distanceBetweenObjects;

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.GetComponent<Collider>().name);
    }
        bool f=true;

    private void Update()
    {
        obj = GameObject.Find("Straight_Terrain_WithRock/Rock_Straight");
        distanceBetweenObjects = Vector3.Distance(transform.position, obj.transform.position);
        if(distanceBetweenObjects < 5 & f){
            Handheld.Vibrate();
            f=false;
        }
        // Debug.DrawLine(transform.position, obj.transform.position, Color.green);
    }
}
