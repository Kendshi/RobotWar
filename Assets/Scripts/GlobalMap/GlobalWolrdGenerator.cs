using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GlobalWolrdGenerator : MonoBehaviour
{
    [SerializeField] private int gridLength;
    [SerializeField] private int gridHeight;
    [SerializeField] private Hex hex;
    [SerializeField] private Transform startPosition;
    [SerializeField] private float cellSize = 1.7f;
    [SerializeField] private Selecter selecter;
    
    private Player _player;

    private List<Hex> _hexagons = new List<Hex>();

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }
    
    private void Awake()
    {
        SpawnHexs();

        _player.SetPosition(GetRandomHexPosition());
    }
    
    public List<Hex> GetHexs() => _hexagons;
    
    private void SpawnHexs()
    {
        Vector3 instantPosition = startPosition.position;

        for (int i = 0; i < gridHeight; i++)
        {
            for (int j = 0; j < gridLength; j++)
            {
                Hex hex = Instantiate(this.hex, instantPosition, Quaternion.identity);
                hex.gameObject.name = $"Hex_{i}{j}";
                hex._selecter = selecter;
                instantPosition.x += cellSize;
                _hexagons.Add(hex.GetComponent<Hex>());
            }

            instantPosition.x = startPosition.position.x;
            instantPosition.z += 1.5f;
            if (i % 2 == 0)
            {
                instantPosition.x = -0.866f;
            }
        }
    }

    private Vector3 GetRandomHexPosition()
    {
        return _hexagons[Random.Range(0, _hexagons.Count)].StayPoint.position;
    }
}