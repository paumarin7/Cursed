using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Desde el Inspector - Añadir al Objeto X AudioSources (x = al número de sonidos que repdroducirá ese Objeto)
 * Deshabilitar CheckBox - OnAwake
 * Deshabilitar CheckBox - Play On Loop
 * 
 * Añadir SoundHandler al Script del Objeto que vaya a reproducir sonidos:
 * private SoundHandler sh;
 * Añadir en la función OnStart()
 * sh = getComponent<SoundHandler>();
 * 
 * Añadir métodos en el momento adecuado:
 * sh.PlayBackground();
 * sh.PlayPlayerAttackHit();
 * sh.PlayPlayerTakeHealth();
 * sh.PlayPlayerDeath();
 * sh.PlayEnemyTakeHealth();
 * sh.PlayEnemyDeath();
 * */

public class SoundHandler : MonoBehaviour
{ 
    public AudioSource[] gameSounds;

    public AudioSource background;

    public AudioSource playerAttackHit;
    public AudioSource playerTakeHealth;
    public AudioSource playerDeath;

    public AudioSource enemyTakeHealth;
    public AudioSource enemyDeath;

        void Start()
    {
        gameSounds = GetComponents<AudioSource>();

        background = gameSounds[0];

        playerAttackHit = gameSounds[1];
        playerTakeHealth = gameSounds[2];
        playerDeath = gameSounds[3];

        enemyTakeHealth = gameSounds[4];
        enemyDeath = gameSounds[5];

    }

    public void PlayBackground()
    {
        background.Play();
    }

    public void PlayPlayerAttackHit()
    {
        playerAttackHit.Play();
    }

    public void PlayPlayerTakeHealth()
    {
        playerTakeHealth.Play();
    }

    public void PlayPlayerDeath()
    {
        playerDeath.Play();
    }

    public void PlayEnemyTakeHealth()
    {
        enemyTakeHealth.Play();
    }

    public void PlayEnemyDeath()
    {
        enemyDeath.Play();
    }


}
