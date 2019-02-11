using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSystem : MonoBehaviour
{
    public static Camera cam;
    public static float height;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        height = cam.orthographicSize * 2;
        this.transform.localScale = new Vector3(height, height, this.transform.position.z);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blox"))
        {
            Destroy(other.gameObject);
        }
    }
}
