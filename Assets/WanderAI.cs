using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAI : MonoBehaviour
{
    Vector3 start_pos;
    Vector3 end_pos;
    int limit=100;
    float lerp_value;

    // Start is called before the first frame update
    void Start()
    {
        GetTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (lerp_value < 1)
        {
            lerp_value += Time.deltaTime * 0.2f;
            transform.position = Vector3.Lerp(start_pos,end_pos,lerp_value);
        }
        else
        {
            GetTargetPosition();
        }
    }

    void GetTargetPosition()
    {
        start_pos = transform.position;
        end_pos = new Vector3(Random.Range(2.5f - limit, limit - 2.5f), 0, Random.Range(-limit, limit + 1));
        transform.rotation = Quaternion.LookRotation((end_pos-start_pos),Vector3.up);

        lerp_value = 0;
    }
}
