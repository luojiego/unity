using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public float speed;

    [Tooltip("最多飞行多少米")]
    public float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        var lifeTime = 1f;
        if (speed > 0)
        {
            lifeTime = maxDistance / speed;
        }


        Invoke("SelfDestroy", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, speed, Space.Self);
    }

    private void SelfDestroy()
    {
       Destroy(this.gameObject); 
    }
}
