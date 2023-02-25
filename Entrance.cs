using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SearchService;

public class Entrance : MonoBehaviour
{
    public string FromExitScreen;
    public static Entrance position;
    private void Start()
    {
        if(FromExitScreen == PlayerController.instance.StorageArea)
        {
            PlayerController.instance.transform.position = transform.position;
        }
    }
}
