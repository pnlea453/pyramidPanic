// Met using kan je een XNA codebibliotheek toevoegen en gebruiken in je class
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

//namespace
namespace PyramidPanic
{
    //classe naam
    public static class Input
    {

    // Fields
    //keyboardStates voor edge-detection
    private static KeyboardState ks, oks;

    // MouseStates voor edge-detection
    private static MouseState ms, oms;

    // Dit is een retangle die aan de muiscursor zit vastgeplakt
    private static Rectangle mouseRect;


    // Constructor
    static Input()
    {
       // keyboard state
        ks = Keyboard.GetState();
        // mouse state
        ms = Mouse.GetState();
        // old keyboard state
        oks = ks;
        // old mouse state
        oms = ms;
        // nieuwe mouserect met de rectangle
        mouseRect = new Rectangle(ms.X, ms.Y, 1, 1);
    }


    // Update
    public static void Update()
    {
        // oks is gelijk aan ks
        oks = ks;
        // oms is gelijk aan ms
        oms = ms;
        //keyboardstate
        ks = Keyboard.GetState();
        // mouse state
        ms = Mouse.GetState();

    }

    // Dit is een edgedetector voor het indrukken van een knop
    public static bool EdgeDetectKeyDown(Keys key)
    {
        //return ks en oks
        return (ks.IsKeyDown(key) && oks.IsKeyUp(key));
    }

    // Dit is een edgedetector voor het loslaten van een knop
    public static bool EdgeDetectKeyUp(Keys key)
    {
        // return ks en oks
        return (ks.IsKeyUp(key) && oks.IsKeyDown(key));
    }

    // Dit is een edgedetector voor het indrukken van de linkermuisknop
    public static bool EdgeDetectMousePressLeft()
    {
        // return ms en oms
        return (ms.LeftButton == ButtonState.Pressed) && 
               (oms.LeftButton == ButtonState.Released);

    }

    // Dit is een edgedetector voor het indrukken van de rechtermuisknop
    public static bool EdgeDetectMousePressRight()
    {
        //return ms en oms
        return (ms.RightButton == ButtonState.Pressed) &&
               (oms.RightButton == ButtonState.Released);

    }

    // Dit is een leveldetector voor het detecteren of een keyboardtoets is ingedrukt
    public static bool LevelDetectKeyDown(Keys key)
    {
        // return iskeydown
        return (ks.IsKeyDown(key));
    }

    // Dit is een leveldetector voor het detecteren of een keyboardtoets is ingedrukt
    public static bool LevelDetectKeyUp(Keys key)
    {
        // return is keyup
        return (ks.IsKeyUp(key));
    }
        // vector 2 position
    public static Vector2 MousePosition()
    {
        // return vector 2
        return new Vector2(ms.X,ms.Y);

    }
        // rectangle mouserect
    public static Rectangle MouseRect()
    {
        // mourect x en y
        mouseRect.X = ms.X;
        mouseRect.Y = ms.Y;
        //return mouserect
        return mouseRect;
    }

    }
}
