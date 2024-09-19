using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class CoinSpawner : Spawner<Coin>
{
    [SerializeField] private float _respawnDuration;

    private Coin _coin;
    private WaitForSeconds _wait;

    private void Awake() => _wait = new WaitForSeconds(_respawnDuration);

    private void OnEnable()
    {
        _coin = Instantiate(Prefab, SpawnPosition.position, quaternion.identity);
        _coin.Collected += Spawn;
    }

    private void OnDisable()
    {
        _coin.Collected -= Spawn;
    }

    protected override void Spawn() => 
        StartCoroutine(SpawnCoinWithDelay());

    private IEnumerator SpawnCoinWithDelay()
    {
        yield return _wait;
        
        _coin.gameObject.SetActive(true);
    }
}
