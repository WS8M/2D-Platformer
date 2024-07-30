using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coins _coinsPrefab;
    [SerializeField] private float _respawnDuration;
    [SerializeField] private Transform _spawnPosition;

    private Coins _coins;

    private void OnEnable()
    {
        _coins = Instantiate(_coinsPrefab, _spawnPosition.position, quaternion.identity);
        _coins.Collected += Respawn;
    }

    private void OnDisable()
    {
        _coins.Collected -= Respawn;
    }

    private void Respawn() => 
        StartCoroutine(SpawnCoinWithDelay());

    private IEnumerator SpawnCoinWithDelay()
    {
        yield return new WaitForSeconds(_respawnDuration);
        
        _coins.gameObject.SetActive(true);
    }
}
