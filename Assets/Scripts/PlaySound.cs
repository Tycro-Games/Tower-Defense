using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour
{
	AudioSource audioSource;
	public AudioClip pre_audio;
	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}
	public  void Play(AudioClip clip)
	{
		if (pre_audio != null)
		{
			audioSource.clip = pre_audio;
			audioSource.Play();
		}
		else
		{
			audioSource.clip = clip;
			audioSource.Play();
		}
	}
}
