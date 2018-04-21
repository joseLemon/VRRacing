using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptions : MonoBehaviour {
    public GameObject MainMenu;
    public GameObject MainCamera;

    public GameObject CarSelectionMenu;
    public GameObject SelectableCar;

    public GameObject TrackSelectionMenu;

    private Animator CameraAnimations;
    private Animator CarAnimations;

    public void Start()
    {
        CameraAnimations = MainCamera.GetComponent<Animator>();
        CarAnimations = SelectableCar.GetComponent<Animator>();
    }

    public void CarSelection()
    {
        StartCoroutine(DoFade(MainMenu));
        CameraAnimations.Play("FlyCameraToCarSelection");
        CarAnimations.SetTrigger("CarSelection");
        StartCoroutine(DoFadeIn(CarSelectionMenu));
    }

    public void TrackSelection()
    {
        StartCoroutine(DoFade(CarSelectionMenu));
        StartCoroutine(DoFadeIn(TrackSelectionMenu));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator DoFade(GameObject UIElement)
    {
        CanvasGroup canvasGroup = UIElement.GetComponent<CanvasGroup>();
        while(canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 2;
            yield return null;
        }
        canvasGroup.interactable = false;
        UIElement.SetActive(false);
        yield return null;
    }

    IEnumerator DoFadeIn(GameObject UIElement)
    {
        yield return new WaitForSeconds(1);
        UIElement.SetActive(true);
        CanvasGroup canvasGroup = UIElement.GetComponent<CanvasGroup>();
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * 2;
            yield return null;
        }
        yield return null;
    }
}
