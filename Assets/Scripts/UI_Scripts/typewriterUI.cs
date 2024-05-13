using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class typewriterUI : MonoBehaviour
{
	TMP_Text _tmpProText;
	string writer;

	[SerializeField] 
	float delayBeforeStart = 0f;
	[SerializeField] 
	float timeBtwChars = 0.001f;
	[SerializeField] 
	string leadingChar = "";
	[SerializeField] 
	bool leadingCharBeforeDelay = false;
	
	public bool _finishWritting = false;
	public bool pressed = false;

	public AudioSource audioSource;
	public AudioClip intro1;
	public AudioClip intro2;
	public AudioClip intro3;
	public AudioClip intro4;
	public AudioClip preparado;

	public int introBtnCounter = 0;

	void Start()
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
		introBtnCounter++;
		audioSource.clip = intro1;
		audioSource.Play();
	}

	public void soundClicked2()
	{
		introBtnCounter++;
		audioSource.clip = intro2;
		audioSource.Play();
	}

	public void soundClicked3()
	{
		introBtnCounter++;
		audioSource.clip = intro3;
		audioSource.Play();
	}

	public void soundClicked4()
	{
		introBtnCounter++;
		audioSource.clip = intro4;
		audioSource.Play();
	}

	public void soundClicked5()
	{
		introBtnCounter++;
		audioSource.clip = preparado;
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
				yield return new WaitForSeconds(0);
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

			typewriterUI typewriter = GameObject.Find("Introduction").GetComponent<typewriterUI>();
			if (typewriter != null)
            {
				typewriter._finishWritting = true;
            }

			Start_Screen startScreen = GameObject.Find("Start_Screen").GetComponent<Start_Screen>();
			if (startScreen != null)
            {
				startScreen.checkFinish();
            }

		}
	}
}
