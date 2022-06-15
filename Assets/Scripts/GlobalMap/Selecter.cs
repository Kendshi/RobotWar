using UnityEngine;

public class Selecter : MonoBehaviour
{
    [SerializeField] private GlobalWolrdGenerator wolrdGenerator;
    [SerializeField] private MapMover mover;
    
    private ISelectable _currentSelected;
    
    private void Start()
    {
        wolrdGenerator.GetHexs().ForEach(hex => hex.OnClickToHex += Select);
    }

    private void OnDestroy()
    {
        wolrdGenerator.GetHexs().ForEach(hex => hex.OnClickToHex -= Select);
    }

    public void Select(ISelectable selectObject)
    {
        if (_currentSelected != null)
            _currentSelected.Unselect();

        _currentSelected = selectObject;
        selectObject.ShowSelectFrame();
        
        if (selectObject is Hex hex)
        {
        }
    }

    public void CheckSelect(Hex hexStayPoint)
    {
        if (_currentSelected != null && _currentSelected is Player player)
        {
            mover.CreatePath(hexStayPoint, player.GetCurrentHex());
        }
    }
}
