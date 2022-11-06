using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskGiverScript : MonoBehaviour
{
    public Task task;

    public GameObject notepad;
    public Text titleText;


    public void OpenNotepad()
    {
        notepad.SetActive(true);
        titleText.text = task.title;
    }


    public void NextTask()
    {
        task.isActive = true;
        
    }
}