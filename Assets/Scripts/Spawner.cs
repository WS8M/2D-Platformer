using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Money _moneyPrefab;
    [SerializeField] private float _respawnDuration;
    [SerializeField] private Transform _spawnPosition;

    private Money _money;

    private void OnEnable()
    {
        _money = Instantiate(_moneyPrefab, _spawnPosition.position, quaternion.identity);
        _money.Collected += Respawn;
    }

    private void OnDisable()
    {
        _money.Collected -= Respawn;
    }

    private void Respawn() => 
        StartCoroutine(SpawnCoinWithDelay());

    private IEnumerator SpawnCoinWithDelay()
    {
        yield return new WaitForSeconds(_respawnDuration);
        
        _money.gameObject.SetActive(true);
    }
}
