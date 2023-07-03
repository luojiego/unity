using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLogic : MonoBehaviour
{
    // 对子弹 prefab 资源的引用
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            TestFire();
        }
    }

    private void TestFire()
    {
        Debug.Log("* 创建子弹的实例 ..");
        GameObject node = Object.Instantiate(bulletPrefab, null);
        node.transform.position = Vector3.zero;
        node.transform.localEulerAngles = Vector3.zero;
    }
}
