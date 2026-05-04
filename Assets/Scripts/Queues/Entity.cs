using UnityEngine;

public class Entity : MonoBehaviour
{
    public EntityStats stats;
    
    void Start()
    {
        GameManager.instance.AutoAdd(this);

        gameObject.name = stats.entityName + " SPD: " + stats.speed;

        GetComponent<Renderer>().material.color = Random.ColorHSV(0, 1f, 0.7f, 1f, 0.8f, 1f);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
