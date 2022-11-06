using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Task 
{

    //Is the Task currently active
    public bool isActive; 

    // Name of the task 
    public string title;
    // How much the anxiety meter goes down after the task is done
    public int anxietylose;

    

    public void Complete()
    {
        isActive = false; 
    }
}
