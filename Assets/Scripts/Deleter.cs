using UnityEngine;

public class Deleter : MonoBehaviour
{
    public void DeleteCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}