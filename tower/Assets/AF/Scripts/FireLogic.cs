using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLogic : MonoBehaviour
{
    // ���ӵ� prefab ��Դ������
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
        Debug.Log("* �����ӵ���ʵ�� ..");
        GameObject node = Object.Instantiate(bulletPrefab, null);
        node.transform.position = Vector3.zero;
        node.transform.localEulerAngles = Vector3.zero;
    }
}
