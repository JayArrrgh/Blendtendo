using UnityEngine;
using System.Collections;

public class ChefScoreboard : CoderScoreboard
{
  ChefScoreboard()
  {
    prefix = "Chicken Cooked: ";
  }

  void Update()
  {
    // TODO: This shouldn't be recreated every frame.
    string scoreString = "";

    scoreString += "Good: "    + ChefMain.NumberOfGoodFoodPrepared + "\n";
    scoreString += "Bad: "     + ChefMain.NumberOfBadFoodPrepared + "\n";
    scoreString += "Trashed: " + ChefMain.NumberOfFoodThrownOut + "\n";

    int total = ChefMain.NumberOfGoodFoodPrepared +
                ChefMain.NumberOfBadFoodPrepared +
                ChefMain.NumberOfFoodThrownOut;
    scoreString += "Total: " + total;

    guiText.text = scoreString;
  }
}
