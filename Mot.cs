using System;
public class Mot
{
    public static string[] motMystere = new string[] // tableau mot a deviner
    {
        "chien", "chat", "maison", "voiture", "arbre", "fleure", "lapin", "train",
    };
    public static string MotRnd() // mot aleatoire
    {
        int index = new Random().Next(0, motMystere.Length);
        string resultat = motMystere[index];
        return resultat;
    }
}