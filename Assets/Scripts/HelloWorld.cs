using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI() {
        if (GUI.Button(new Rect(20, 17, 200, 100), "Test")) {
            Debug.Log("Test button");
        }
    }
}
    