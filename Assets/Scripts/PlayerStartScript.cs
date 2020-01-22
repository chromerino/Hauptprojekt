using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStartScript : Bolt.EntityBehaviour<IPlayerState>
{
    [SerializeField] private GameObject world;
    [SerializeField] private GameObject UI_Canvas;
    [SerializeField] private AudioClip[] m_FootstepSounds;
    [SerializeField] private AudioClip m_JumpSound;
    [SerializeField] private AudioClip m_LandSound;
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip[] WeaponSounds;
    public GameObject healthbar;
    public GameObject PlayerCharacter;

    public override void Attached()
    {
        if (!entity.IsOwner)
        {
            Destroy(world);
            Destroy(UI_Canvas);
        }
    }

    public void PlayFootstepSound()
    {
        m_AudioSource.clip = m_LandSound;
        m_AudioSource.Play();
    }

    public void PlayJumpSound()
    {
        m_AudioSource.clip = m_LandSound;
        m_AudioSource.Play();
    }

    public void PlayLandingSound()
    {
        m_AudioSource.clip = m_LandSound;
        m_AudioSource.Play();
    }

    public void PlayWeaponSound(int index)
    {
        if (index >= WeaponSounds.Length || index < 0) return;
        m_AudioSource.clip = WeaponSounds[index];
        m_AudioSource.Play();
    }

    public void TogglePlayerVisibility(bool visibility)
    {
        PlayerCharacter.SetActive(visibility);
    }
}
