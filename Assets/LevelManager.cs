using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
	static GameObject instance;

	void Start()
	{
		if (instance == null)
		{
			DontDestroyOnLoad(gameObject);
			instance = gameObject;
		}
		else if (gameObject != instance)
		{
			Destroy(gameObject);
		}
	}

	public void LoadNextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void LoadScene(string name)
	{
		SceneManager.LoadScene(name);
	}

	public void LoadScene(int buildIndex)
	{
		SceneManager.LoadScene(buildIndex);
	}

	public void LoadSceneAsync(string name)
	{
		StartCoroutine(CoroutineLoadScene(name));
	}

	public void LoadSceneAsync(int buildIndex)
	{
		StartCoroutine(CoroutineLoadScene(buildIndex));
	}

    IEnumerator CoroutineLoadScene(string name)
    {
        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the Scene by build //number.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

	IEnumerator CoroutineLoadScene(int buildIndex)
    {
        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the Scene by build //number.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(buildIndex);

        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
