using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public string SceneToLoad;
    public string EntranceScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            SceneManager.LoadScene(SceneToLoad);
            PlayerController.instance.StorageArea = EntranceScreen;
        }
    }
/*    public IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(1f);
        SceneFade.Play("CrossFade_End");
    }*/
}
