using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    [Tooltip("子弹的预制体")]
    public GameObject bulletPrefab;

    [Tooltip("子弹生成位置")]
    public Transform bulletFields;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateBullte", 1, 1);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateBullte()
    {
        var bullet = Object.Instantiate(bulletPrefab, bulletFields);
        bullet.transform.localPosition = Vector3.zero;
        Debug.Log("bullet: " + bullet);
        bullet.transform.eulerAngles = this.transform.eulerAngles;
        var bulletLogic = bullet.GetComponent<BulletLogic>();
        bulletLogic.speed = 0.2f;
        bulletLogic.maxDistance = 1f;
    }
}
