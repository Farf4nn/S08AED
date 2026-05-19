using UnityEngine;
using UnityEngine.InputSystem;

public class DictionaryGameManager : MonoBehaviour
{
    [SerializeField] private DataBaseEntitys database;

    private InputSystem_Actions inputs;

    private void Awake()
    {
        inputs = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputs.Enable();

        inputs.Player.SpawnCommon.performed += OnSpawnCommon;
        inputs.Player.SpawnRare.performed += OnSpawnRare;
        inputs.Player.SpawnEpic.performed += OnSpawnEpic;
        inputs.Player.SpawnLegendary.performed += OnSpawnLegendary;
    }

    private void OnDisable()
    {
        inputs.Player.SpawnCommon.performed -= OnSpawnCommon;
        inputs.Player.SpawnRare.performed -= OnSpawnRare;
        inputs.Player.SpawnEpic.performed -= OnSpawnEpic;
        inputs.Player.SpawnLegendary.performed -= OnSpawnLegendary;

        inputs.Disable();
    }

    private void OnSpawnCommon(InputAction.CallbackContext context)
    {
        SpawnLoot(Rarity.Common);
    }

    private void OnSpawnRare(InputAction.CallbackContext context)
    {
        SpawnLoot(Rarity.Rare);
    }

    private void OnSpawnEpic(InputAction.CallbackContext context)
    {
        SpawnLoot(Rarity.Epic);
    }

    private void OnSpawnLegendary(InputAction.CallbackContext context)
    {
        SpawnLoot(Rarity.Legendary);
    }

    private void SpawnLoot(Rarity rarity)
    {
        BaseEntityData item = database.GetRandomEntity(rarity);

        if (item == null)
            return;

        Vector3 randomPos = new Vector3(
            Random.Range(-5, 5),
            0,
            Random.Range(-5, 5)
        );

        Instantiate(item.prefab, randomPos, Quaternion.identity);

        Debug.Log($"Spawned: {item.EntityName}");
    }
}
