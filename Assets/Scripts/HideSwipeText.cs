using System.Collections;
using UnityEngine;
using Lean.Transition;

public class HideSwipeText : MonoBehaviour
{

    public float delay = 3f;

    private bool isHidden = false;

    private LeanManualAnimation anim;

    private void Start() => anim = GetComponent<LeanManualAnimation>();

    //TODO
    //ADD PLAYERPREFS

    private void Update()
    {
        if (!isHidden)
            StartCoroutine(HideText());
    }

    private IEnumerator HideText()
    {
        isHidden = true;
        yield return new WaitForSeconds(delay);
        if (anim != null)
            anim.BeginTransitions();

        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
