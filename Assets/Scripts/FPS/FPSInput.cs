using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public const float baseSpeed = 6.0f;
    private CharacterController _charController;
    void Awake() 
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDestroy() 
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        //Time.deltaTime: the amount of time between frames
        //transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        //返回moverment的模，最长不超过speed
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        //movement是本地坐标系下的值（往左移动是往player的左边移动），转换为世界坐标系
        movement = transform.TransformDirection(movement);
        //movement接收一个世界坐标系下的移动量
        _charController.Move(movement);

    } 

    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }
}
