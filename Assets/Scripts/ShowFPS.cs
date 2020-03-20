using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowFPS : MonoBehaviour
{
    private float _lastUpdateShowTime = 0f;
    private float _updateShowDeltaTime = 0.01f;
    private int _frameUpdate = 0;
    private float _FPS = 0f;
    private bool _showing = false;
    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        _lastUpdateShowTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        _frameUpdate++;
        if (Time.realtimeSinceStartup - _lastUpdateShowTime >= _updateShowDeltaTime) {
            _FPS = _frameUpdate / (Time.realtimeSinceStartup - _lastUpdateShowTime);
            _frameUpdate = 0;
            _lastUpdateShowTime = Time.realtimeSinceStartup;
        }
        if (Input.GetKeyDown(KeyCode.F1)) {
            _showing = !_showing;
        }
    }
    void OnGUI()
    {
        if (_showing) {
            string text = "FPS: " + _FPS;
            GUIStyle style = new GUIStyle();
            style.fontSize = 30;
            style.normal.textColor = new Color( 1, 0, 0 );
            GUI.Label(new Rect(10, 0, 300, 300 ), text, style );
        }
    }
}
