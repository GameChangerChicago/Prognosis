using UnityEngine;
using System.Collections;

[System.Serializable]

//class that sets an Audio Source with the settings defined by the user
//and starts and stops it with a method
public class Sound
{
    private AudioSource _audioSource;

    //more variables can be added in order to have a more customized audio source component
    //(i.e. priority, mute, etc.)
    //only the basics were selected here for the sake of testing
    public string ClipName;
    public AudioClip Clip;

    [Range(0f, 1f)]
    public float Volume;
    [Range(0f, 3f)]
    public float Pitch;

    public bool Loop;
    public bool PlayOnAwake;

    public void SetSource(AudioSource _source)
    {
        _audioSource = _source;
        _audioSource.clip = Clip;
        _audioSource.volume = Volume;
        _audioSource.pitch = Pitch;
        _audioSource.loop = Loop;
        _audioSource.playOnAwake = PlayOnAwake;
    }//end SetSource method

    public void Play()
    {
        _audioSource.Play();
    }//end Play method

    public void Stop()
    {
        _audioSource.Stop();
    }//end Stop method
}//end Sound class

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    //creates an array of sounds that can be added to in the editer
    [SerializeField]
    Sound[] SoundArray;

    /*
    public AudioClip Winning, BackgroundMusic;
	public float FadeTime;
	public AudioSource AudioSource, SourceWinning;
	private GameManager _gameManager;
    */

    //called at startup
    void Awake()
    {
        //checks to make sure that the AudioManager is not null
        if(instance == null)
        {
            instance = this;
        }
        //destroys the gameObject if the AudioManager is incorrectly instantiated
        else if(instance != this){
            Destroy(gameObject);
        }

    }//end Awake method

	//initializes
	void Start () {
	
		//_gameManager = FindObjectOfType<GameManager> ();

        //loop through the sound array and initialize each sound as an audio source
        for(int i = 0; i < SoundArray.Length; i++)
        {
            GameObject _specificSound = new GameObject(SoundArray[i].ClipName + " Audio Source");
            _specificSound.transform.SetParent(transform);
            SoundArray[i].SetSource(_specificSound.AddComponent<AudioSource>());
        }//end for loop

        PlaySound("Background Music");

       // BackgroundMusic.
		//audioSource = this.GetComponent<AudioSource> ();

	}

    //checks to see if the sound being called exists in array, then plays it
    public void PlaySound(string _name)
    {
        for(int i = 0; i < SoundArray.Length; i++)
        {
            if(SoundArray[i].ClipName == _name)
            {
                SoundArray[i].Play();
                return;
            }//end if sound has been found
        }//end for loop searching for sound
    }//end PlaySound method
	
	void Update() {

        /*
		if (_gameManager.winning) {
			_gameManager.winning = !_gameManager.winning;
			SourceWinning.PlayOneShot(Winning, .7f);
			StartCoroutine(FadeSoundOut(AudioSource));

			StartCoroutine(FadeSoundIn(AudioSource));
		}
        */
	}

	/*IEnumerator FadeSoundOut(AudioSource audio){
		float t = FadeTime;


		while (t > 0) {
			yield return null;
			t -= Time.deltaTime;
			audio.volume = (t / FadeTime);
		}yield return new WaitForSeconds (5);

		//yield return new WaitForSeconds(2f);
	}

	IEnumerator FadeSoundIn(AudioSource audio){
		float t = 0f;

		while (t < FadeTime) {
			yield return null;

			t+=Time.deltaTime;

			audio.volume = t/FadeTime;
		}yield return new WaitForSeconds (5);

		//yield return new WaitForSeconds (2f);

	}*/
}
