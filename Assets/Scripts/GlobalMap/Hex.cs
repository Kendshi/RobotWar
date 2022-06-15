using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class Hex : MonoBehaviour, ISelectable
{
    [SerializeField] private Renderer model;
    [SerializeField] private Outline outline;
    [SerializeField] private Transform stayPoint;
    [SerializeField] private LayerMask layer;
    [SerializeField] private ParticleSystem frame;
    
    public event Action<ISelectable> OnClickToHex;
    [HideInInspector]
    public List<Hex> _neighborHexs = new List<Hex>(8);
    public Transform StayPoint => stayPoint;
    
    public Selecter _selecter;

    private void Start()
    {
        model.material.SetTextureOffset("_BaseMap", new Vector2(Random.Range(0f, 1f),Random.Range(0f, 1f)));
        Findneighbors();
    }

    public void ShowSelectFrame()
    {
        frame.Play();
    }

    public void Unselect()
    {
        frame.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    public void ClickOnObject()
    {
        OnClickToHex?.Invoke(this);
    }

    public void ClickOnRightButton()
    {
        _selecter.CheckSelect(this);
    }

    private void Findneighbors()
    {
        Collider[] colliders = new Collider[8];
        int colliderNumber = Physics.OverlapSphereNonAlloc(stayPoint.position, 1f, colliders, layer);
        for (int i = 0; i < colliderNumber; i++)
        {
            var hex = colliders[i].GetComponentInParent<Hex>();
            
            if (hex == this)
                continue;

            _neighborHexs.Add(hex);
        }
    }

    
}