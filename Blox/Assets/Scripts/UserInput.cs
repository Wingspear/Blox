using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public Spawn spawner;
    public GameObject spawnPointStart, spawnPointFinish;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (this.transform.position.y < spawnPointStart.transform.position.y - spawner.lengthBlox)
            {
                this.transform.position += new Vector3(0, spawner.lengthBlox, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (this.transform.position.x > spawnPointStart.transform.position.x + spawner.lengthBlox)
            {
                this.transform.position -= new Vector3(spawner.lengthBlox, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (this.transform.position.y > spawnPointFinish.transform.position.y + spawner.lengthBlox)
            {
                this.transform.position -= new Vector3(0, spawner.lengthBlox, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (this.transform.position.x < spawnPointFinish.transform.position.x - spawner.lengthBlox)
            {
                this.transform.position += new Vector3(spawner.lengthBlox, 0, 0);
            }
        }
    }
}
