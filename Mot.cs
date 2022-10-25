using System;
public class Mot
{
    static string[] motMystere = new string[] 
    {
        "chien", "chat"
    };
    public static string MotRnd()
    {
        int index = new Random().Next(0, motMystere.Length);
        string resultat = motMystere[index];

        return resultat;
    }
}