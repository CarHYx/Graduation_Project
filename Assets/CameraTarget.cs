using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {

    }
    void LateUpdate()
    {
        if (target != null)
        {
            Vector2 targetPos = target.position;
            transform.position = Vector2.Lerp(new Vector2(this.transform.position.x,this.transform.position.y), targetPos, Time.deltaTime * moveSpeed);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }
}
