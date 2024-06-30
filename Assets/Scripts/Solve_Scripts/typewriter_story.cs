using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class typewriter_story : MonoBehaviour
{
	TMP_Text _tmpProText;
	string writer;

	[SerializeField]
	float delayBeforeStart = 0f;
	[SerializeField]
	float timeBtwChars = 0.1f;
	[SerializeField]
	string leadingChar = "";
	[SerializeField]
	bool leadingCharBeforeDelay = false;

	public bool _finishWritting = false;
	bool pressed = false;

	public AudioSource audioSource;
	public AudioClip story1;
	public AudioClip story2;
	public AudioClip story3;
	public AudioClip story4;
	public AudioClip story5;
	public AudioClip story6;
	public AudioClip story7;
	public AudioClip story8;
	public AudioClip story9;
	public AudioClip story10;
	public AudioClip story11;
	public AudioClip storyCorrect;
	public AudioClip storyIncorrect;

	public int storyBtnCounter = 0;

	public void Start()
	{
		_tmpProText = GetComponent<TMP_Text>()!;

		if (_tmpProText != null)
		{
			writer = _tmpProText.text;
			_tmpProText.text = "";
			StartCoroutine("TypeWriterTMP");
		}
	}

	public void Update()
	{

		if (Input.GetKeyDown(KeyCode.S))
		{
			pressed = true;
		}

	}


	public void soundClicked1()
	{
		storyBtnCounter++;
		audioSource.clip = story1;
		audioSource.Play();
	}

	public void soundClicked2()
	{
		storyBtnCounter++;
		audioSource.clip = story2;
		audioSource.Play();
	}

	public void soundClicked3()
	{
		storyBtnCounter++;
		audioSource.clip = story3;
		audioSource.Play();
	}

	public void soundClicked4()
	{
		storyBtnCounter++;
		audioSource.clip = story4;
		audioSource.Play();
	}

	public void soundClicked5()
	{
		storyBtnCounter++;
		audioSource.clip = story5;
		audioSource.Play();
	}

	public void soundClicked6()
	{
		storyBtnCounter++;
		audioSource.clip = story6;
		audioSource.Play();
	}

	public void soundClicked7()
	{
		storyBtnCounter++;
		audioSource.clip = story7;
		audioSource.Play();
	}

	public void soundClicked8()
	{
		storyBtnCounter++;
		audioSource.clip = story8;
		audioSource.Play();
	}

	public void soundClicked9()
	{
		storyBtnCounter++;
		audioSource.clip = story9;
		audioSource.Play();
	}

	public void soundClicked10()
	{
		storyBtnCounter++;
		audioSource.clip = story10;
		audioSource.Play();
	}

	public void soundClicked11()
	{
		storyBtnCounter++;
		audioSource.clip = story11;
		audioSource.Play();
	}

	public void soundClickedCorrect()
	{
		storyBtnCounter++;
		audioSource.clip = storyCorrect;
		audioSource.Play();
	}

	public void soundClickedIncorrect()
	{
		storyBtnCounter++;
		audioSource.clip = storyIncorrect;
		audioSource.Play();
	}

	IEnumerator TypeWriterTMP()
	{
		_tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";

		yield return new WaitForSeconds(delayBeforeStart);

		foreach (char c in writer)
		{
			if (_tmpProText.text.Length > 0)
			{
				_tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
			}
			_tmpProText.text += c;
			_tmpProText.text += leadingChar;
			if (pressed == false)
			{
				yield return new WaitForSeconds(timeBtwChars);
			}


		}

		if (leadingChar != "")
		{
			_tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
		}
		else
		{
			_finishWritting = true;
			pressed = false;

			//Para explicar el test de caras
			typewriter_story typewriter = GameObject.Find("story").GetComponent<typewriter_story>();
			if (typewriter != null)
			{
				typewriter._finishWritting = true;
			}
			Story story = GameObject.Find("story").GetComponent<Story>();
			if (story != null)
			{

				story.checkFinish();
			}

		}
	}
}
