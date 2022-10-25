using System;
using System.Collections.Generic;
public class Partie
{
    public List<string> lettrePropose = new List<string>();
    public void PartieEnCours()
    {
        bool SaisieCorrecte(string saisieJoueur)
        {
            string motADeviner = Mot.MotRnd();
            return Char.IsLetter(saisieJoueur[0]);
        }

        bool partie = true;
        string motADeviner = Mot.MotRnd();
        Console.WriteLine("[Propose une Lettre pour deviner le mot ou écrit le mot directement.]");
        Console.WriteLine("debug.Le mot a deviner est : " + motADeviner);

        while (partie == true)
        {
            string saisieJoueur = Console.ReadLine();
            bool saisieCorrecte = SaisieCorrecte(saisieJoueur);
            Console.WriteLine("[Vous avez saisie : " + (saisieJoueur) + ".]");

            if (saisieCorrecte)
            {
                if (motADeviner.Contains(saisieJoueur))
                {
                    Console.WriteLine("[Bien joué ! Le mot a deviner contien cette lettre.]");
                    Console.WriteLine("[Lettre(s) déjà jouée(s) : " + lettrePropose + ".]");
                }
                else
                {
                    Console.WriteLine("[Dommage.. Le mot a deviner ne contien pas cette lettre.]");
                    Console.WriteLine("[Lettre(s) déjà jouée(s) : " + lettrePropose + ".]");
                }
                if (!lettrePropose.Contains(saisieJoueur))
                {
                    lettrePropose.Add(saisieJoueur);
                }
                if (saisieJoueur == motADeviner)
                {
                    Console.WriteLine("[Le mot a deviner étais bien : " + motADeviner + ".]");
                    partie = false;
                }
            }

            else
            {
                Console.WriteLine("[La saisie est incorrecte..]");
            }
        }
    }
}