using System;
using System.Collections.Generic;
public class Partie
{
    public List<string> lettrePropose = new List<string>(); // nouvelle liste mot
    public int nmbrEssaie = 0;
    public int essaieMax = 10;
    public int affichagePendu;
    public string motADeviner;
    public int essaieRestant
    {
        get
        {
            return essaieMax - nmbrEssaie;
        }
    }
    public int afficherLettreDevine;
    public int afficherLettrePropose; 
    public GameManager gameManager;
    bool partieGagnee // bool verif partie gagnee
    {
        get
        {
            for (int i = 0; i < motADeviner.Length; i++)
            {
                if (!lettrePropose.Contains(motADeviner[i].ToString()))
                {
                    return false;
                }
            }
            return true;
        }
    }
    public Partie(GameManager gameManager) // lancement
    {
        this.gameManager = gameManager;
        gameManager.partieEnCours = this;
        BouclePrincipale(); // entree en boucle principale
    }
    public void BouclePrincipale() // boucle principale
    {
        Console.Clear(); // clear
        gameManager.affichagePendu.AfficherEcran(this); 
        bool partie = true;
        motADeviner = Mot.MotRnd(); // mot a deviner
        int incorrect;
        bool SaisieCorrecte(string saisieJoueur) // sasie correcte
        {
            //string motADeviner = Mot.MotRnd();
            return Char.IsLetter(saisieJoueur[0]);
        }
        while (partie == true)
        {
            if (partieGagnee) // verif partie gagnee
            {
                gameManager.affichagePendu.AfficherEcranGagnée(this);
            }
            gameManager.affichagePendu.AfficherInfoPartie(this);
            string saisieJoueur = Console.ReadLine();
            gameManager.affichagePendu.AfficherMessage("", ConsoleColor.White);
            gameManager.affichagePendu.AfficherMessage("|J'ai saisi : " + saisieJoueur + ".|", ConsoleColor.White);
            bool saisieCorrecte = SaisieCorrecte(saisieJoueur);
            if ((saisieJoueur.Length) > 1)
            {
                saisieCorrecte = false;
            }
            else if (Int32.TryParse(saisieJoueur, out incorrect)) // sasie correcte
            {
                saisieCorrecte = false;
            }
            if (saisieCorrecte == false)
            {
                gameManager.affichagePendu.AfficherMessage("|La saisie est incorrect..|", ConsoleColor.Yellow); // message erreur
            }
            else if (saisieCorrecte)
            {
                if (!lettrePropose.Contains(saisieJoueur))
                {
                    lettrePropose.Add(saisieJoueur);
                }
                if (!motADeviner.Contains(saisieJoueur))
                {
                    nmbrEssaie++; // -1 essaie
                    gameManager.affichagePendu.AfficherMessage("|Dommage ! Le mot a deviner ne contien pas cette lettre.|", ConsoleColor.Red); // lettre non valide
                }
                if (motADeviner.Contains(saisieJoueur))
                {
                    gameManager.affichagePendu.AfficherMessage("|Bien joué ! Le mot a deviner contien bien la lettre : " + saisieJoueur + " .|", ConsoleColor.Green); // affichage lettre valide
                }
                if (nmbrEssaie == essaieMax) // plus d'essaies
                {
                    gameManager.affichagePendu.AfficherEcranPerdue(this); // affichage perdu
                }
            }
            System.Threading.Thread.Sleep(750); // latence
        }
        BouclePrincipale(); // retour dand la boucle principale
    }
}