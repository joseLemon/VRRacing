using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitConfig : MonoBehaviour
{
    public GameObject PlayerCar;
    public GameObject AICarsContainer;
    public List<Material> MaterialList = new List<Material>();

    public static List<Transform> AICars = new List<Transform>();

    public static GameInitConfig instance = null;

    // the singleton instance is set
    private void Awake()
    {
        instance = this;
    }

    // singleton instance to be able to access controller data
    public static GameInitConfig Instance
    {
        get
        {
            return instance;
        }
    }

    private void Start()
    {
        /*
         * Set the material list to use in the selection screen and at the track, will be used
         * for applying the selected player skin and randomly select the ai cars skins
         * Sets a random material for the ai cars within the material list range
         */
        PlayerCar.GetComponent<Renderer>().material = MaterialList[PlayerPrefs.GetInt("SelectedCar")];

        foreach (Transform AICar in AICarsContainer.transform)
        {
            // add car to list
            AICars.Add(AICar);
            AICar.GetChild(0).GetChild(0).GetComponent<Renderer>().material = MaterialList[Random.Range(0, (MaterialList.Count - 1))];
        }
    }
}
