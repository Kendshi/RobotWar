using UnityEngine;

public class MouseCallBack: MonoBehaviour
{
    [SerializeField] private GameObject selected;
    
    private void OnMouseDown()
    {
        if (selected.TryGetComponent(out ISelectable selectedObject))
        {
            selectedObject.ClickOnObject();
        }
    }
    
}
