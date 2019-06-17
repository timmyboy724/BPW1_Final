using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossEnd : MonoBehaviour
{


    // Update is called once per frame
    public void End()
    {
    StartCoroutine(WaitForDeath());
}

IEnumerator WaitForDeath()
{
    yield return new WaitForSeconds(5f);
    Debug.Log("scene load");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

}
}
