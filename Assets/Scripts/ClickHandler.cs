using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Deleter _deleter;

    [SerializeField] private float _minExplosionForce = 5f;
    [SerializeField] private float _maxExplosionForce = 50f;
    [SerializeField] private float _minExplosionRadius = 3f;
    [SerializeField] private float _maxExplosionRadius = 10f;

    private float _scaleMultiplier = 2f;

    private int _minCubesCount = 2;
    private int _maxCubesCount = 7;

    private float _chanceMultiplier = 0.5f;

    private void OnEnable()
    {
        _raycaster.CubeClicked += CubeClicked;
    }

    private void OnDisable()
    {
        _raycaster.CubeClicked -= CubeClicked;
    }

    private void CubeClicked(Cube cube)
    {
        Vector3 position = cube.transform.position;
        float scale = cube.transform.localScale.x / _scaleMultiplier;

        int newCubesCount = Random.Range(_minCubesCount, _maxCubesCount);
        float newSplitChance = cube.SplitChance * _chanceMultiplier;

        if (Random.value <= cube.SplitChance)
        {
            List<Cube> newCubes = _spawner.SpawnCubes(position, scale, newCubesCount, newSplitChance);

            float explosionForce = Mathf.Lerp(_maxExplosionForce, _minExplosionForce, scale);
            float explosionRadius = Mathf.Lerp(_maxExplosionRadius, _minExplosionRadius, scale);

            _exploder.Explode(position, newCubes, explosionForce, explosionRadius);
            Debug.Log($"{explosionForce} Сила");
            Debug.Log($"{explosionRadius} Радиус");
        }

        _deleter.DeleteCube(cube);
    }
}
