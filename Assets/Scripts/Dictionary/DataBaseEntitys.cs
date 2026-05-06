using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "DataBaseEntitys", menuName = "Scriptable Objects/DataBaseEntitys")]
public class DataBaseEntitys : SerializedScriptableObject
{
    [FoldoutGroup("References"), PreviewField(150)]
    public GameObject entityPrefab;
    
    public Dictionary<Rarity, List<BaseEntityData>> dataBaseEntitys = new();

    public BaseEntityData GetRandomEntity(Rarity rarity)
    {
        if (dataBaseEntitys.TryGetValue(rarity, out List<BaseEntityData> entities))
        {
            return entities[Random.Range(0,entities.Count)];
        }
        else
        {
            throw new System.Exception("La rareza definida no existe");
        }
    }

    //removerlo a otra clase y compactarlo a un game manager singleton
    public GameObject InstantiateEntity(Rarity rarity, Vector3 position)
    {
        GameObject obj = Instantiate(entityPrefab);
        //obj.GetComponent<BaseEntityData>().Set(GetRandomEntity(rarity));
        obj.transform.position = position;


        return null;
    }
}
