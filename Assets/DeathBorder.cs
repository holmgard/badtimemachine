using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBorder : MonoBehaviour
{
    public TextMeshProUGUI victorText;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("Player"))
        {
            victorText.text = collision.gameObject.name + " eliminated";
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2.0F);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
