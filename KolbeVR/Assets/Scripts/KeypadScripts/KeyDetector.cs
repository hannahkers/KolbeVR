
using UnityEngine;
using TMPro;
using System;

public class KeyDetector : MonoBehaviour
{

    private TextMeshPro display;

    private KeyPadControll keyPadControll;

    // Start is called before the first frame update
    void Start()
    {
        display = GameObject.FindGameObjectWithTag("Display").GetComponentInChildren<TextMeshPro>();
        display.text = "";

        keyPadControll = GameObject.FindGameObjectWithTag("Keypad").GetComponent<KeyPadControll>();


        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KeypadButton"))
        {
            var key = other.GetComponentInChildren<TextMeshPro>();
            if (key != null)
            {
                var keyFeedBack = other.gameObject.GetComponent<KeyFeedback>();

                if (key.text == "Back")
                {
                    if (display.text.Length > 0)
                        display.text = display.text.Substring(0, display.text.Length - 1);
                }
                else if (key.text == "Enter")
                {
                    var accessGranted = false;
                    bool onlyNumbers = int.TryParse(display.text, out int value);
                    if (onlyNumbers == true && display.text.Length > 0)
                    {
                        accessGranted = keyPadControll.CheckIfCorrect(Convert.ToInt32(display.text));
                    }

                    if (accessGranted == true)
                    {
                        display.text = "Start";
                    }
                    else
                    {
                        display.text = "Retry";
                    }
                }
                else if (key.text == "Cancel")
                {
                    display.text = "";
                }
                else
                {
                    //test if ther is letters on the display if so empty display before adding new number
                    bool onlyNumbers = int.TryParse(display.text, out int value);
                    if (onlyNumbers == false)
                    {
                        display.text = "";

                    }

                    //make sure that this is max 4 numbers on display
                    if (display.text.Length < 4)
                        display.text += key.text;
                }
                keyFeedBack.keyHit = true;

            }

        }

    }
}
