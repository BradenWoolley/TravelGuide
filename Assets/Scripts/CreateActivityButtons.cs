using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateActivityButtons : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform parent;

    private ActivityHandler handler;

    [SerializeField]
    private int buttonsToPool = 10;
    [SerializeField]
    private List<GameObject> buttonPool;

    public void SetHandler(ActivityHandler handler) => this.handler = handler;

    private void Start()
    {
        buttonPool = new List<GameObject>();

        for (int i = 0; i < buttonsToPool; i++)
        {
            var temp = GameObject.Instantiate(buttonPrefab, parent);
            temp.SetActive(false);
            buttonPool.Add(temp);
        }
    }
    [Obsolete("Method is deprecated, please use CreateNewActivity(List<Activity> activities) instead")]
    public void CreateNewActivity(Activity activity)
    {
        foreach (var requestedButton in buttonPool)
        {
            if (!requestedButton.activeInHierarchy)
            {
                TMP_Text name = requestedButton.GetComponentInChildren<TMP_Text>();
                name.text = activity.activityName;
                Button btn = requestedButton.GetComponent<Button>();
                btn.onClick.AddListener(() => handler.ShowCurrentActivity(activity));
                requestedButton.SetActive(true);
                break;
            }
        }
    }
    /// <summary>
    /// Creates a button dynamically for each activity
    /// </summary>
    /// <param name="activities">List of activities</param>
    public void CreateNewActivity(List<Activity> activities)
    {
        int buttonIndex = 0;
        foreach(var activity in activities)
        {
            //Ensures only one button per activity
            int count = 0;
            while (count < 1)
            {
                //Creates new ui elements if necesarry
                if(buttonIndex >= buttonPool.Count)
                {
                    var temp = GameObject.Instantiate(buttonPrefab, parent);
                    buttonPool.Add(temp);
                    temp.GetComponentInChildren<TMP_Text>().text = activity.activityName;
                    temp.GetComponent<Button>().onClick.AddListener(() => handler.ShowCurrentActivity(activity));
                    count++;
                }

                else
                {
                    if (!buttonPool[buttonIndex].activeInHierarchy)
                    {
                        buttonPool[buttonIndex].SetActive(true);
                        buttonPool[buttonIndex].GetComponentInChildren<TMP_Text>().text = activity.activityName;
                        buttonPool[buttonIndex].GetComponent<Button>().onClick.AddListener(() => handler.ShowCurrentActivity(activity));
                        count++;
                    }
                }

                buttonIndex++;
            }
            
        }
    }
    /// <summary>
    /// Clears the buttons from the screen
    /// </summary>
    public void RemoveButtons()
    {
        foreach (var button in buttonPool)
        {
            if (button.activeInHierarchy)
            {
                TMP_Text name = button.GetComponentInChildren<TMP_Text>();
                name.text = null;
                button.GetComponent<Button>().onClick.RemoveAllListeners();
                button.SetActive(false);
            }

            button.SetActive(false);
        }
    }
}
