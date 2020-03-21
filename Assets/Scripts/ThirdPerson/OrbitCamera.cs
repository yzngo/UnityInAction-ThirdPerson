using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    public float rotSpeed = 1.5f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotY;
    private float _rotX;
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
        //第三人称, 跟随鼠标旋转
        float horInput = Input.GetAxis("Horizontal");
        if(horInput != 0) {
            _rotY += horInput * rotSpeed;
        } else {
            _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;
        }
        
        _rotX -= Input.GetAxis("Mouse Y") * rotSpeed * 4;
        _rotX = Mathf.Clamp(_rotX, minimumVert, maximumVert);

        // 1. 旋转的角度
        Quaternion rotation = Quaternion.Euler(_rotX, _rotY, 0);
        // 2. 旋转偏移量, 并计算相机的新位置
        transform.position = target.position - (rotation * _offset);
        // 3. 相机指向目标
        transform.LookAt(target);
        // Vector3 tar = new Vector3( target.position.x, transform.position.y, target.position.z);
        // transform.LookAt( tar );

        //////////////////////////////////////////////////
        //第三人称, 俯视视角
        _rotY -= Input.GetAxis("Horizontal") * rotSpeed;
        Quaternion rotation2 = Quaternion.Euler(0, _rotY, 0);
        transform.position = target.position - (rotation2 * _offset);
        transform.LookAt(target);
    }
}
