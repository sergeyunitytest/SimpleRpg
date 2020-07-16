using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimytControler : MonoBehaviour
{
    /*public List<Transform> points = new List<Transform>();
    public float speed = 2f;
    private Vector3 Pos;
    private int Stage = 0;
    private float startTime;
    private float journeyLength;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[0].position;
        Stage = 1;
        Pos = transform.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(points[0].position, points[1].position);

    }

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(Pos, points[Stage].position, fractionOfJourney);
        if (transform.position == points[Stage].position)
        {
            if(points.Count<= Stage + 1)
            {
                Pos = transform.position;
                startTime = Time.time;
                journeyLength = Vector3.Distance(points[Stage].position, points[0].position);
                Stage = 1;
            }
            else
            {
                Stage++;
                Pos = transform.position;
                startTime = Time.time;
                journeyLength = Vector3.Distance(points[0].position, points[1].position);
            }
        }
    }*/
}
