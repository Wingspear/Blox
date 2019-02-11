using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blox : MonoBehaviour
{
    private float speed = 0f;

    // Update is called once per frame
    void Update()
    {
        //move toward user
        this.gameObject.transform.position -= transform.forward * speed * Time.deltaTime;
    }

    public void SetSpeed(float s)
    {
        speed = s;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
