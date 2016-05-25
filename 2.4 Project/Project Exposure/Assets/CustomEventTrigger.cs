﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


[System.Serializable]
public class CustomEventTrigger : MonoBehaviour {

    [SerializeField]
    public enum Action {
        PlaySound, PlayAnimation, PlayCameraPath, ActivateInteractable, DeactivateInteractable, ShowHint, PlayParticle, StopParticle, FocusOnTarget, ActivateLight, DisableLight, ChangeLightValues, ChangeImageEffects, ActivateObject, DeactivateObject
    };

    [SerializeField]
    public enum OnTrigger {
        OnTriggerEnter, OnTriggerExit, OnTriggerStay
    };

    [System.Serializable]
    public struct info {
        public Action action;

        [SerializeField]
        public OnTrigger onTrigger;

        [SerializeField]
        public bool activated;

        //bool if activated
        //[SerializeField]
        //public bool activated;

        //gameobject
        [SerializeField]
        public GameObject go;

        // audioclip to play
        [SerializeField]
        public AudioClip audioClip;

        // play animation
        [SerializeField]
        public AnimationClip animation;

        // activate / deactivate interactable
        [SerializeField]
        public BaseInteractable interactable;

        //camera cutscene
        [SerializeField]
        public GameObject path;

        //start hint
        [SerializeField]
        public Image image;

        [SerializeField]
        public Sprite sprite;

        //particle
        [SerializeField]
        public ParticleSystem particle;

        //light stuff
        [SerializeField]
        public Light light;

        [SerializeField]
        public Color color;

        [SerializeField]
        public float intensity;

        [SerializeField]
        public float bounceIntensity;

        [SerializeField]
        public float range;
    }

    [SerializeField]
    public info[] Go;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter() {
        for (int i = 0; i < Go.Length; i++) {
            if (Go[i].onTrigger == OnTrigger.OnTriggerEnter) {
                switch (Go[i].action) {
                    case Action.ActivateInteractable:
                        Go[i].interactable.Activate();
                        break;
                    case Action.DeactivateInteractable:
                        Go[i].interactable.DeActivate();
                        break;
                    case Action.PlayAnimation:
                        Go[i].go.GetComponent<Animation>().clip = Go[i].animation;
                        Go[i].go.GetComponent<Animation>().Play();
                        break;
                    case Action.PlayCameraPath:
                        Camera.main.GetComponent<CameraControl>().StartCutscene(Go[i].path);
                        break;
                    case Action.PlaySound:
                        Go[i].go.GetComponent<AudioSource>().clip = Go[i].audioClip;
                        Go[i].go.GetComponent<AudioSource>().Play();
                        break;
                    case Action.ShowHint:
                        //gotyn
                        break;
                    case Action.ActivateLight:
                        Go[i].light.enabled = true;
                        break;
                    case Action.DisableLight:
                        Go[i].light.enabled = false;
                        break;
                    case Action.ChangeLightValues:
                        if (Go[i].light.range != null) {
                            Go[i].light.range = Go[i].range;
                        }
                        Go[i].light.color = Go[i].color;
                        Go[i].light.intensity = Go[i].intensity;
                        Go[i].light.bounceIntensity = Go[i].bounceIntensity;
                        break;
                    case Action.ActivateObject:
                        Go[i].go.SetActive(true);
                        break;
                    case Action.DeactivateObject:
                        Go[i].go.SetActive(false);
                        break;
                    case Action.PlayParticle:
                        Go[i].particle.Play();
                        break;
                    case Action.StopParticle:
                        Go[i].particle.Stop();
                        break;
                    case Action.FocusOnTarget:
                        //camera focus
                        break;
                }
            }
        }
    }

    void OnTriggerStay() {
        for (int i = 0; i < Go.Length; i++) {
            if (Go[i].onTrigger == OnTrigger.OnTriggerStay) {
                switch (Go[i].action) {
                    case Action.ActivateInteractable:
                        Go[i].interactable.Activate();
                        break;
                    case Action.DeactivateInteractable:
                        Go[i].interactable.DeActivate();
                        break;
                    case Action.PlayAnimation:
                        Go[i].go.GetComponent<Animation>().clip = Go[i].animation;
                        Go[i].go.GetComponent<Animation>().Play();
                        break;
                    case Action.PlayCameraPath:
                        Camera.main.GetComponent<CameraControl>().StartCutscene(Go[i].path);
                        break;
                    case Action.PlaySound:
                        Go[i].go.GetComponent<AudioSource>().clip = Go[i].audioClip;
                        Go[i].go.GetComponent<AudioSource>().Play();
                        break;
                    case Action.ShowHint:
                        //gotyn
                        break;
                    case Action.ActivateLight:
                        Go[i].light.enabled = true;
                        break;
                    case Action.DisableLight:
                        Go[i].light.enabled = false;
                        break;
                    case Action.ChangeLightValues:
                        if (Go[i].light.range != null) {
                            Go[i].light.range = Go[i].range;
                        }
                        Go[i].light.color = Go[i].color;
                        Go[i].light.intensity = Go[i].intensity;
                        Go[i].light.bounceIntensity = Go[i].bounceIntensity;
                        break;
                    case Action.ActivateObject:
                        Go[i].go.SetActive(true);
                        break;
                    case Action.DeactivateObject:
                        Go[i].go.SetActive(false);
                        break;
                    case Action.PlayParticle:
                        Go[i].particle.Play();
                        break;
                    case Action.StopParticle:
                        Go[i].particle.Stop();
                        break;
                    case Action.FocusOnTarget:
                        //camera focus
                        break;
                }
            }
        }
    }

    void OnTriggerExit() {
        for (int i = 0; i < Go.Length; i++) {
            if (Go[i].onTrigger == OnTrigger.OnTriggerExit) {
                switch (Go[i].action) {
                    case Action.ActivateInteractable:
                        Go[i].interactable.Activate();
                        break;
                    case Action.DeactivateInteractable:
                        Go[i].interactable.DeActivate();
                        break;
                    case Action.PlayAnimation:
                        Go[i].go.GetComponent<Animation>().clip = Go[i].animation;
                        Go[i].go.GetComponent<Animation>().Play();
                        break;
                    case Action.PlayCameraPath:
                        Camera.main.GetComponent<CameraControl>().StartCutscene(Go[i].path);
                        break;
                    case Action.PlaySound:
                        Go[i].go.GetComponent<AudioSource>().clip = Go[i].audioClip;
                        Go[i].go.GetComponent<AudioSource>().Play();
                        break;
                    case Action.ShowHint:
                        //gotyn
                        break;
                    case Action.ActivateLight:
                        Go[i].light.enabled = true;
                        break;
                    case Action.DisableLight:
                        Go[i].light.enabled = false;
                        break;
                    case Action.ChangeLightValues:
                        if (Go[i].light.range != null) {
                            Go[i].light.range = Go[i].range;
                        }
                        Go[i].light.color = Go[i].color;
                        Go[i].light.intensity = Go[i].intensity;
                        Go[i].light.bounceIntensity = Go[i].bounceIntensity;
                        break;
                    case Action.ActivateObject:
                        Go[i].go.SetActive(true);
                        break;
                    case Action.DeactivateObject:
                        Go[i].go.SetActive(false);
                        break;
                    case Action.PlayParticle:
                        Go[i].particle.Play();
                        break;
                    case Action.StopParticle:
                        Go[i].particle.Stop();
                        break;
                    case Action.FocusOnTarget:
                        //camera focus
                        break;
                }
            }
        }
    }
}

