using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Goal : MonoBehaviour
{
    public GameObject goal;
    public float rotspeed = 10f;
    public float speed = 0;
    public float acceln = 5f;
    public float deccln = 5f;
    public int Brakeangle = 30;
    public float minspeed = 0f;
    public float maxspeed = 100f;
    public float maxtempspeed = 100f;

    public bool isPlayer = false;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                maxspeed /= 1.5f;
            }
            else
            {
                maxspeed = maxtempspeed;
            }
        }

        Vector3 lookatgoal = new Vector3(goal.transform.position.x, this.transform.position.y, goal.transform.position.z);
        Vector3 dir = lookatgoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(dir), rotspeed * Time.deltaTime);
        if(Vector3.Angle(this.transform.forward,goal.transform.forward)>Brakeangle && speed>15)
        {
            speed = Mathf.Clamp(speed - deccln, minspeed, maxspeed);
        }
        else
        {
            speed = Mathf.Clamp(speed + acceln, minspeed, maxspeed);
        }
        transform.Translate(0, 0, speed * Time.deltaTime);

    }
}
