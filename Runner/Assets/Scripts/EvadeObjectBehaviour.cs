using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeObjectBehaviour : MonoBehaviour
{
    Vector3 goalpos;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 25;
        goalpos = transform.position;
        goalpos = new Vector3(goalpos.x, goalpos.y, -160);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, goalpos, Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, goalpos) < 5)
        {
            Destroy(gameObject);
        }
    }
}
