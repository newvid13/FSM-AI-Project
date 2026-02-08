using UnityEngine;

public class PatrolPoints : MonoBehaviour
{
    [SerializeField] Transform[] points;
    int currentPoint;

    public bool HasReachedPoint()
    {
        if (Vector3.Distance(transform.position, points[currentPoint].position) < 1)
        {
            return true;
        }

        return false;
    }

    public Transform GetCurrentPoint()
    {
        return points[currentPoint];
    }

    public Transform GetNextPoint()
    {
        currentPoint++;

        if (currentPoint >= points.Length)
            currentPoint = 0;

        return points[currentPoint];
    }
}
