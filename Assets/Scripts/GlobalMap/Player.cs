using System;
using UnityEditor;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, ISelectable
{
    [SerializeField] private ParticleSystem frame;
    [SerializeField] private LayerMask hexLayer;
    private Selecter _selecter;
    
    [Inject]
    public void Construct(Selecter selecter)
    {
        _selecter = selecter;
    }
    
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
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
        _selecter.Select(this);
    }

    public void ClickOnRightButton()
    {
        
    }

    public Hex GetCurrentHex()
    {
        Ray ray = new Ray(transform.position + Vector3.up, Vector3.down);
        Physics.Raycast(ray, out RaycastHit hit, 10f, hexLayer);
        return hit.transform.GetComponentInParent<Hex>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position + Vector3.up, Vector3.down);
    }
}
