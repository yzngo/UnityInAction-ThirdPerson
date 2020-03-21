using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class ResetScale : MonoBehaviour
{
    [MenuItem("CONTEXT/RectTransform/重置变换")]
    static void Operate(MenuCommand cmd)
    {
        RectTransform trans = cmd.context as RectTransform;
        Vector2 size = trans.sizeDelta;
        trans.sizeDelta = new Vector2( trans.sizeDelta.x * trans.localScale.x, 
                            trans.sizeDelta.y * trans.localScale.y );
        trans.localScale = Vector3.one;
    }
}