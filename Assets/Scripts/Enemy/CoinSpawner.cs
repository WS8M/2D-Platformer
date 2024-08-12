using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private float _respawnDuration;
    [SerializeField] private Transform _spawnPosition;

    private Coin _coin;
    private WaitForSeconds _wait;

    private void Awake() => _wait = new WaitForSeconds(_respawnDuration);

    private void OnEnable()
    {
        _coin = Instantiate(_coinPrefab, _spawnPosition.position, quaternion.identity);
        _coin.Collected += Respawn;
    }

    private void OnDisable()
    {
        _coin.Collected -= Respawn;
    }

    private void Respawn() => 
        StartCoroutine(SpawnCoinWithDelay());

    private IEnumerator SpawnCoinWithDelay()
    {
        yield return _wait;
        
        _coin.gameObject.SetActive(true);
    }
}
