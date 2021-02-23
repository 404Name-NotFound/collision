
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    private float transition = 0.0f;
    private float animationDuration = 3.0f;
    private Vector3 animationOffset = new Vector3(0,5,0);

    void Update()
    {
        Vector3 desiredpos = target.position + offset;
        Vector3 smoothpos = Vector3.Lerp (transform.position, desiredpos, smoothSpeed);

        if(transition > 1.0f){
            transform.position = smoothpos;

            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                transform.RotateAround(desiredpos,target.transform.up,-90);
            }
            if(Input.GetKeyDown(KeyCode.RightArrow)){
                transform.RotateAround(desiredpos,target.transform.up,90);
            }
        }   
        else{
            transform.position = Vector3.Lerp(target.position + animationOffset,target.position,transition);
            transition += Time.deltaTime * 1/animationDuration;
            transform.LookAt(target.position + new Vector3(0,0,1));
        }
    }
}
