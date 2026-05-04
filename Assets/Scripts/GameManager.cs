using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //public MyQueue<string> BankQueue = new();
    public static GameManager instance;

    public PriorityQueue<Entity> priorityQueue =
        new(  (a,b) => a.stats.speed > b.stats.speed  );

    public List<Entity> entities = new();

    private void Awake()
    {
        instance = this;    
    }


    void Start()
    {
        
    }
    public void AutoAdd(Entity entity)
    {
        entities.Add(entity);
    }
    [Button]
    public void EnqueueAll()
    {
        foreach (var entity in entities)
        {
            Enqueue(entity);
        }
    }
    [Button]
    public void Enqueue(Entity entity)
    {
        priorityQueue.Enqueue(entity);
    }
    [Button]
    public void Dequeue()
    {
        priorityQueue.Peek().gameObject.transform.position = Vector3.up * priorityQueue.Count * 1.5f;
        Debug.Log("Pase a ser atendido : " + priorityQueue.Dequeue().stats.entityName);

      
    }
    [Button]
    public void Peek()
    {
        Debug.Log("El siguiente en ser atendido sera ... " + priorityQueue.Peek().stats.entityName);
    }

    [Button]
    public void Clear()
    {
        priorityQueue.Clear();  
    }

    [Button]
    public void Count()
    {
        Debug.Log(priorityQueue.Count);
    }



}
