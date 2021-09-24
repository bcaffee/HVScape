using UnityEngine;
using UnityEngine.UI;

public class InfoMenu : MonoBehaviour
{

    [SerializeField]
    private MainMenu MainMenu;

    [SerializeField]
    private Button BackBtn;

    [SerializeField]
    private Text HowToPlay;

    [SerializeField]
    private Text GameObjective;

    void Start()
    {
        SetHowToPlay();
        SetObjective();
    }

    private void SetHowToPlay()
    {
        HowToPlay.text = "How to Play: Long Distance Movement: Press down on the joystick and then aim/angle it to the spot you want to spawn for teleportaion.\n" +
            "Picking up an object: Move one of your hands to the object you want to pick up until it is outlined in yellow, and then hold down the trigger to grip it.\n" +
            "Note: You can teleport with one hand and pick up an object with the other.";
    }

    private void SetObjective()
    {
        GameObjective.text = "Backstory: You were hiding in your Chemistry teacher's class all night to obtain your and your friends' phones that got taken away.\n" +
            "You sucessfully did that, although, now you need to get out.\n" +
            "The door has locked from the inside for some weird reason. The only way to get out is to complete certain puzzles around the class.\n" +
            "The puzzles include:\n" +
            "* Properly putting the textbooks back on the shelf\n" +
            "* Balancing the scale with the model atoms\n" +
            "* Turning the projector on by placing the power cords into the right plugs.\nTry to finish as fast as possible before school starts again!";
    }
}