using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    /// <summary>
    /// Deals with the audio for the car
    /// </summary>

    AudioManager _audioManager;

    //audio related vars
    enum CarEngineSounds
    {
        CarForwardEngine,
        CarReverseEngine,
        CarIdleEngine,
        CarMudEngine,
    }

    enum CarEffectSounds
    {
        GearFilp,
        NONE
    }


    CarEngineSounds _newcarEngineSounds = CarEngineSounds.CarIdleEngine;
    CarEngineSounds _oldCarEngineSounds = CarEngineSounds.CarIdleEngine;

    CarEffectSounds _carNewEffectSounds;

    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start()
    {
        _audioManager.Play("CarEngineStart");
    }

    public void SoundHandler(float verticalDirection ,float horizontalDirection , bool OnRoad )
    {
        _newcarEngineSounds = verticalDirection > 0 ? CarEngineSounds.CarForwardEngine : CarEngineSounds.CarReverseEngine;

        if (verticalDirection == 0)
        {
            _newcarEngineSounds = CarEngineSounds.CarIdleEngine;
        }

        if (!OnRoad)
        {
            _newcarEngineSounds = CarEngineSounds.CarMudEngine;
        }

        //EngineSound
        if (_newcarEngineSounds != _oldCarEngineSounds)
        {
            _audioManager.Stop(_oldCarEngineSounds.ToString());
            _oldCarEngineSounds = _newcarEngineSounds;
            _audioManager.Play(_oldCarEngineSounds.ToString());

            _carNewEffectSounds = CarEffectSounds.GearFilp;
            _audioManager.Play(_carNewEffectSounds.ToString());
        }
    }
}
