using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivitySwitcher : MonoBehaviour
{
    [SerializeField]
    private TMP_Text activityName, description;

    [SerializeField]
    private Image logo;

    [SerializeField]
    private Sprite defaultLogo;

    public static ActivitySwitcher switcher;

    private string url = null;

    private void Start() => switcher = this;

    public void SetInfo(string name, string description, Sprite logo, string url)
    {
        this.activityName.text = name;
        this.description.text = description;

        if (logo != null)
        {
            this.logo.sprite = logo;
            this.url = url;
        }

        if (url != null)
            this.url = url;
    }

    public void ClearInfo()
    {
        this.activityName.text = null;
        this.description.text = null;
        this.logo.sprite = defaultLogo;
        this.url = null;
    }

    public void OpenWeb()
    {
        if (!string.IsNullOrWhiteSpace(url))
            Application.OpenURL(url);
    }
}
