﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
	public void LoadNextScene()
	{
		SceneManager.LoadScene(1);
	}
}
