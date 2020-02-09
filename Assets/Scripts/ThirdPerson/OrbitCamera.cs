using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    public float rotSpeed = 1.5f;

    private float _rotY;
    private Vector3 _offset;
    // Start is called before the first frame update
    void Start()
    {
        _rotY = transform.eulerAngles.y;
        _offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        float horInput = Input.GetAxis("Horizontal");
        if(horInput != 0) {
            _rotY += horInput * rotSpeed;
        } else {
            _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;
        }
        // 1. 旋转的角度
        Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
        // 2. 旋转偏移量, 并计算相机的新位置
        transform.position = target.position - (rotation * _offset);
        // 3. 相机指向目标
        transform.LookAt(target);
    }
}
