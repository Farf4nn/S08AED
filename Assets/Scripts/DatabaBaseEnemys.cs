using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DatabaBaseEnemys", menuName = "Scriptable Objects/DatabaBaseEnemys")]
public class DatabaBaseEnemys : SerializedScriptableObject
{
    public Dictionary<string, GameObject> test = new();
    [HorizontalGroup("Split", width: 80)]
    [PreviewField(80), HideLabel]
    public Sprite Icono;

    [VerticalGroup("Split/Info")]
    [LabelText("Nombre del Item")]
    public string ItemName;

    [VerticalGroup("Split/Info")]
    [PropertySpace(SpaceBefore = 5)]
    [TextArea(3, 5)]
    public string Descripcion;
}
