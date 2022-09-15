using UnityEngine;

public class PositionSpawnPoints : MonoBehaviour
{
    private Resolution _resolution;
    private bool ResolutionsAreEqual(Resolution a, Resolution b)
    {
        return a.width == b.width && a.height == b.height;
    }

    private Vector3 GetHorizontalPosition(Bounds cameraBounds)
    {
        float offset = Constants.SpawnPoint.OffSet;
        float y = Random.Range(cameraBounds.min.y - offset, cameraBounds.max.y + offset);
        float x;
        if (Random.Range(0, 2) == 0)
        {
            x = cameraBounds.min.x - offset;
        }
        else
        {
            x = cameraBounds.max.x + offset;
        }
        return new Vector3(x, y, 0f);
    }

    private Vector3 GetVerticalPosition(Bounds cameraBounds)
    {
        float offset = Constants.SpawnPoint.OffSet;
        float x = Random.Range(cameraBounds.min.x - offset, cameraBounds.max.x + offset);
        float y;
        if (Random.Range(0, 2) == 0)
        {
            y = cameraBounds.min.y - offset;
        }
        else
        {
            y = cameraBounds.max.y + offset;
        }
        return new Vector3(x, y, 0f);
    }

    private void MoveSpawnPoints()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(Constants.Tags.Respawn);
        Bounds bounds = Utils.Cameras.OrthographicBounds(Camera.main);
        Vector3 newPosition;
        foreach (GameObject spawnPoint in spawnPoints)
        {
            if (Random.Range(0, 2) == 0)
            {
                newPosition = GetVerticalPosition(bounds);
            }
            else {
                newPosition = GetHorizontalPosition(bounds);
            }
            spawnPoint.transform.position = newPosition;
        }
    }

    private void Awake()
    {
        MoveSpawnPoints();
    }

    private void Start()
    {
        _resolution = Screen.currentResolution;
    }

    private void Update()
    {
        if(!ResolutionsAreEqual(_resolution, Screen.currentResolution))
        {
            _resolution = Screen.currentResolution;
            MoveSpawnPoints();
        }
    }
}
