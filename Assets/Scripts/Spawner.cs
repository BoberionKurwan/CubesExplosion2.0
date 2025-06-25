using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    public List<Cube> SpawnCubes(Vector3 centerPosition, float scale, int count, float splitChance)
    {
        List<Cube> newCubes = new List<Cube>();

        for (int i = 0; i < count; i++)
        {
            Cube cube = Instantiate(_cube);
            cube.transform.position = centerPosition + Random.insideUnitSphere * scale;
            cube.transform.localScale = Vector3.one * scale;
            cube.Initialize(splitChance);

            newCubes.Add(cube);
        }

        return newCubes;
    }
}
