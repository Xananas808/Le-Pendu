public class AfficherPendu
{
    public GameManager gameManager;
    public int nmbrEssaie = 0;
    public int essaieMax = 10;
    public List<string> lettrePropose = new List<string>();
    public AfficherPendu(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }
    public void AfficherLettresCachees() // affichage lettres cachees
    {
        string resultat = "";
        for (int i = 0; i < gameManager.partieEnCours.motADeviner.Length; i++)
        {
            if (gameManager.partieEnCours.lettrePropose.Contains(gameManager.partieEnCours.motADeviner[i].ToString()))
            {
                resultat += gameManager.partieEnCours.motADeviner[i];
            }
            else
            {
                resultat += " _ ";
            }
        }
        Console.WriteLine(resultat); // _
    }
    public void AfficherLettreDejaJouee() // afficher lettre deja joue
    {
        string resultat = "";

        for (int i = 0; i < gameManager.partieEnCours.lettrePropose.Count; i++)
        {
            resultat += " " + gameManager.partieEnCours.lettrePropose[i] + " |";
        }
        AfficherMessage("|Lettre(s) déjà jouée(s) :|" + resultat, ConsoleColor.White); // afficher message
    }
    public void AfficherMessage(string message, ConsoleColor color) // afficher message
    {
        Console.ForegroundColor = color; // couleur
        Console.WriteLine(message); // txt
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void AfficherPotence(int essaieRestant)
    {
        int index = 10 - essaieRestant;
        Console.WriteLine(visual[index]);
    }
    public void AfficherInfoPartie(Partie partie) // affichage general 
    {
        Console.Clear();
        AfficherMessage("|Il te reste " + partie.essaieRestant + " essaie.|", ConsoleColor.White); // affichage ressaie restant
        AfficherPotence(partie.essaieRestant); // affichage ressaie restant*
        AfficherLettreDejaJouee(); // affichage lettre deja jouee
        AfficherMessage("|Propose une lettre pour deviner le mot :| debug." + gameManager.partieEnCours.motADeviner, ConsoleColor.White); // messgae 
        AfficherLettresCachees(); // affichage lettre mot caché
    }
    public string[] visual = new string[] // visual pendu
    {
@"
|
|
|
|
| 
",
@"
| ╔
| |
| |
| |
| ╚ 
",
@"
| ╔
| |
| |
| |
| ╚══════ 
",
@"
| ╔════╗ 
| |
| |    
| |
| ╚══════ 
",
@"
| ╔════╗ 
| |   
| |    
| |>   
| ╚══════ 
",
@"
| ╔════╗ 
| |<   
| |    
| |>   
| ╚══════ 
",
@"
| ╔════╗ 
| |<   0
| |    
| |>   
| ╚══════ 
",
@"
| ╔════╗ 
| |<   0
| |    |
| |>   
| ╚══════ 
",
@"
| ╔════╗ 
| |<   0
| |    |
| |>   I
| ╚══════ 
",
@"
| ╔═══/|
| |< / 0
| | /  |
| |/   I
| ╚══════ 
"
    };
    public void AfficherEcranGagnée(Partie partie) // ecran gagne
    {
        Console.Clear();
        gameManager.affichagePendu.AfficherMessage(" _   _    ____   _   _   _____   __   __    ____   _   _ ", ConsoleColor.Green);
        gameManager.affichagePendu.AfficherMessage("| | | |  / _  | | | | | |  ___) |  |_/  |  / _  | | | | |", ConsoleColor.Green);
        gameManager.affichagePendu.AfficherMessage("| | | | | |_| | |  || | | |     |       | | |_| | |  || |", ConsoleColor.Green);
        gameManager.affichagePendu.AfficherMessage("|  _  | |  _  | |     | | | 0   | ||_/| | |  _  | |     |", ConsoleColor.Green);
        gameManager.affichagePendu.AfficherMessage("| | | | | | | | | ||  | | | |   | |   | | | | | | | ||  |", ConsoleColor.Green);
        gameManager.affichagePendu.AfficherMessage("|_| |_| |_| |_| |_| |_| |_| I   |_|   |_| |_| |_| |_| |_|", ConsoleColor.Green);
        gameManager.affichagePendu.AfficherMessage("", ConsoleColor.Green);
        gameManager.affichagePendu.AfficherMessage("|Bien joué ! Le mot a deviner étais bien : " + gameManager.partieEnCours.motADeviner + ".|", ConsoleColor.Green);
        System.Threading.Thread.Sleep(3500); 
        Console.Clear();
        gameManager.RestartChoice();
    }
    public void AfficherEcranPerdue(Partie partie) // ecran perdu 
    {
        Console.Clear(); 
        gameManager.affichagePendu.AfficherMessage(" _   _    ____   _   _   _____   __   __    ____   _   _ ", ConsoleColor.Red);
        gameManager.affichagePendu.AfficherMessage("| | | |  / _  | | | | | |  ___) |  |_/  |  / _  | | | | |", ConsoleColor.Red);
        gameManager.affichagePendu.AfficherMessage("| | | | | |_| | |  || | | | 0   |       | | |_| | |  || |", ConsoleColor.Red);
        gameManager.affichagePendu.AfficherMessage("|  _  | |  _  | |     | | | |   | ||_/| | |  _  | |     |", ConsoleColor.Red);
        gameManager.affichagePendu.AfficherMessage("| | | | | | | | | ||  | | | I   | |   | | | | | | | ||  |", ConsoleColor.Red);
        gameManager.affichagePendu.AfficherMessage("|_| |_| |_| |_| |_| |_| |_|     |_|   |_| |_| |_| |_| |_|", ConsoleColor.Red);
        gameManager.affichagePendu.AfficherMessage("", ConsoleColor.Red);
        gameManager.affichagePendu.AfficherMessage("|Perdu.. Le mot étais : " + gameManager.partieEnCours.motADeviner + ".|", ConsoleColor.Red);
        System.Threading.Thread.Sleep(3500); 
        Console.Clear(); 
        gameManager.RestartChoice();
    }
    public void AfficherEcran(Partie partie) // ecran intro
    {
        Console.Clear(); 
        System.Threading.Thread.Sleep(1250); 
        gameManager.affichagePendu.AfficherMessage(" _   _    ____   _   _   _____   __   __    ____   _   _ ", ConsoleColor.White);
        System.Threading.Thread.Sleep(250);
        gameManager.affichagePendu.AfficherMessage("| | | |  / _  | | | | | |  ___) |  |_/  |  / _  | | | | |", ConsoleColor.White);
        System.Threading.Thread.Sleep(250);
        gameManager.affichagePendu.AfficherMessage("| | | | | |_| | |  || | | | 0   |       | | |_| | |  || |", ConsoleColor.White);
        System.Threading.Thread.Sleep(250);
        gameManager.affichagePendu.AfficherMessage("|  _  | |  _  | |     | | | |   | ||_/| | |  _  | |     |", ConsoleColor.White);
        System.Threading.Thread.Sleep(250);
        gameManager.affichagePendu.AfficherMessage("| | | | | | | | | ||  | | | I   | |   | | | | | | | ||  |", ConsoleColor.White);
        System.Threading.Thread.Sleep(250);
        gameManager.affichagePendu.AfficherMessage("|_| |_| |_| |_| |_| |_| |_|     |_|   |_| |_| |_| |_| |_|", ConsoleColor.White);
        System.Threading.Thread.Sleep(1250);
        Console.Clear(); 
        gameManager.affichagePendu.AfficherMessage(" _   _    ____   _   _   _____   __   __    ____   _   _ ", ConsoleColor.White);
        gameManager.affichagePendu.AfficherMessage("| | | |  / _  | | | | | |  ___) |  |_/  |  / _  | | | | |", ConsoleColor.White);
        gameManager.affichagePendu.AfficherMessage("| | | | | |_| | |  || | | |     |       | | |_| | |  || |", ConsoleColor.White);
        gameManager.affichagePendu.AfficherMessage("|  _  | |  _  | |     | | | 0   | ||_/| | |  _  | |     |", ConsoleColor.White);
        gameManager.affichagePendu.AfficherMessage("| | | | | | | | | ||  | | | |   | |   | | | | | | | ||  |", ConsoleColor.White);
        gameManager.affichagePendu.AfficherMessage("|_| |_| |_| |_| |_| |_| |_| I   |_|   |_| |_| |_| |_| |_|", ConsoleColor.White);
        System.Threading.Thread.Sleep(1250); 
        Console.Clear(); 
    }
}