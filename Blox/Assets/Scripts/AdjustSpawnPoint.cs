using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustSpawnPoint : MonoBehaviour
{
    public static Camera cam;
    public static float halfHeight;
    public static float halfWidth;

    //walls
    public GameObject wall1, wall2;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        halfHeight = cam.orthographicSize;
        halfWidth = cam.aspect * halfHeight;
        if (this.gameObject.CompareTag("SpawnStart"))
        {
            this.transform.position = new Vector3(this.transform.position.x, halfHeight, this.transform.position.z);
            wall1.transform.position = new Vector3(this.transform.position.x, 0);
            wall2.transform.position = new Vector3(0, this.transform.position.y);
        }
        else if (this.gameObject.CompareTag("SpawnFinish"))
        {
            this.transform.position = new Vector3(this.transform.position.x, -halfHeight, this.transform.position.z);
            wall1.transform.position = new Vector3(this.transform.position.x, 0);
            wall2.transform.position = new Vector3(0, this.transform.position.y);
        }
    }
}
