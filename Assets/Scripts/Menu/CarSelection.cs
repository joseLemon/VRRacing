using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelection : MonoBehaviour {
    //public float rVelocity = 0.5f;
    public List<Material> MaterialList = new List<Material>();

    private int maxList;
    private int currentSelection;

    private void Start()
    {
        /*
         * If a car selection hasn't occured previously, select the first available material
         * Set the current selection to the saved option
         * Set the max list index of the materials
         * Set the car material from the current selection and reflect it on the game view
         */
        if (!PlayerPrefs.HasKey("SelectedCar"))
            PlayerPrefs.SetInt("SelectedCar", 0);

        currentSelection = PlayerPrefs.GetInt("SelectedCar");
        maxList = MaterialList.Count - 1;

        setCarMaterial();
    }

    // Update is called once per frame
    void Update () {
        // Continiously rotate the preview of the player car
        //gameObject.transform.Rotate(new Vector3(0, rVelocity, 0));
	}

    public void selectLeft()
    {
        // Move to the previous car selection option and show it in game view
        currentSelection--;
        setCarMaterial();
    }

    public void selectRight()
    {
        // Move to the next car selection option and show it in game view
        currentSelection++;
        setCarMaterial();
    }

    void setCarMaterial()
    {
        /*
         * Checking if the max item on list has been reached to go back to the beggining, or,
         * checking if it is at first element and then go back to the last item on list
         * Render the new material from list
         */
        if (currentSelection > maxList)
            currentSelection = 0;
        else if (currentSelection < 0)
            currentSelection = maxList;

        transform.GetComponent<Renderer>().material = MaterialList[currentSelection];
    }

    public void finishSelection()
    {
        // Define the final player selection and save it
        PlayerPrefs.SetInt("SelectedCar", currentSelection);
    }
}
