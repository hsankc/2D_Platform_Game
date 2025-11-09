using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMenager : MonoBehaviour
{
    public Transform target;

    public Transform target2;

    public float cameraSpeed;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      

        if (target.position != null)
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), cameraSpeed);

        }

        else if (target2.position == null)
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(target2.position.x, target2.position.y, transform.position.z), cameraSpeed);
        }


    }
}
