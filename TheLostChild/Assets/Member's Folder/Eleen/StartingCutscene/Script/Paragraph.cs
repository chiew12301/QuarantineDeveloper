using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Paragraph", menuName = "Paragraph")]
[System.Serializable]
public class Paragraph : ScriptableObject
{
    
    public float textSpeed = 0.1f;
    [TextArea(1, 10)]
    public string sentences;
}
