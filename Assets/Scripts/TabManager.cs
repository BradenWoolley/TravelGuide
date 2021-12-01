using UnityEngine;
using Lean.Transition;

public class TabManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tabs;

    private LeanManualAnimation select, deSelect;

    private void Start() => SetActiveTab(1);
    public void SetActiveTab(int tabIndex)
    {
        if (deSelect != null)
            deSelect.BeginTransitions();

        deSelect = null;
        select = null;

        if (tabIndex > tabs.Length - 1)
            return;

        select = tabs[tabIndex].transform.GetChild(0).GetComponent<LeanManualAnimation>();
        deSelect = tabs[tabIndex].transform.GetChild(1).GetComponent<LeanManualAnimation>();

        if (select != null)
            select.BeginTransitions();
    }
}
