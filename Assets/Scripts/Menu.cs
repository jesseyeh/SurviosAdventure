﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

  public GameObject mainMenuHolder;
  public GameObject creditsHolder;
  public Image transition;

  public Camera menuCamera;
  public Transform player;

  public void MainMenu() {

    mainMenuHolder.SetActive(true);
    creditsHolder.SetActive(false);
  }

  public void NewGame() {

    mainMenuHolder.SetActive(false);
    StartCoroutine(Transition(Color.clear, Color.white, 3));
    Cursor.visible = false;
  }

  public void Credits() {

    mainMenuHolder.SetActive(false);
    creditsHolder.SetActive(true);
  }

  public void Quit() {

    Application.Quit();
  }

  private IEnumerator Transition(Color from, Color to, float duration) {
    
    float percent = 0;

    // fade from clear to white
    while(percent < 1) {
      percent += Time.deltaTime / duration;
      transition.color = Color.Lerp(from, to, percent);
      yield return null;
    }

    menuCamera.gameObject.SetActive(false);
    player.gameObject.SetActive(true);

    yield return new WaitForSeconds(1f);

    percent = 0;
    // fade from white to clear
    while(percent < 1) {
      percent += Time.deltaTime / duration;
      transition.color = Color.Lerp(to, from, percent);
      yield return null;
    }
  }
}