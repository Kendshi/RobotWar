using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMover : MonoBehaviour
{
    [SerializeField] private LineRenderer pathLine;

    public List<Vector3> pathPoints = new List<Vector3>();
    private Hex _currentHex;
    private Hex _targetHex;
    
    public void CreatePath(Hex target, Hex startPoint)
    {
        pathPoints.Clear();
        pathPoints.Add(startPoint.StayPoint.position);

        _currentHex = startPoint;
        _targetHex = target;

        int count = 0;

        while (_currentHex != target)
        {
            AddPathPoint();
            count++;

            if (count == 100)
            {
                Debug.Log($"too many operation for create path");
                break;
            }
        }
        
        SetUpLine();
    }

    private void AddPathPoint()
    {
        float minDistance = Mathf.Infinity;
        Hex nearestHex = _currentHex;
        
        foreach (var hex in _currentHex._neighborHexs)
        {
            float currentHexDist = Vector3.Distance(hex.StayPoint.position, _targetHex.StayPoint.position);
            
            if (currentHexDist < minDistance)
            {
                minDistance = currentHexDist;
                nearestHex = hex;
            }
        }

        _currentHex = nearestHex;
        pathPoints.Add(_currentHex.StayPoint.position);
    }

    private void SetUpLine()
    {
        pathLine.positionCount = pathPoints.Count;
        for (int i = 0; i < pathPoints.Count; i++)
        {
           pathLine.SetPosition(i, pathPoints[i]);
        }
    }
}
