using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DoorOpenDevice : MonoBehaviour
{
    [SerializeField] private Vector3 dPos;

    private bool _open;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Operate() {
        if (_open) {
            Vector3 pos = transform.position - dPos;
            transform.DOMove( pos, 1 );
            // transform.position = pos;
        } else {
            Vector3 pos = transform.position + dPos;
            transform.DOMove( pos, 1 );
            transform.position = pos;
        }
        _open = !_open;
    }
}
