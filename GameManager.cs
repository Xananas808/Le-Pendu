public class GameManager
{
    public Partie partieEnCours;
    public AfficherPendu affichagePendu;
    public GameManager() // game manager
    {
        affichagePendu = new AfficherPendu(this);
        NouvellePartie();
    }
    public void NouvellePartie() // nouvelle partie 
    {
        partieEnCours = new Partie(this);
    }
    public void RestartChoice() // restart
    {
        int action = 0;
        bool choice = false;
        while (choice == false)
        {
            affichagePendu.AfficherMessage("|Rejouer ? (1: Oui, 2: Non)|", ConsoleColor.White); // restart message
            while (true)
            {
                string recu = Console.ReadLine();
                if (int.TryParse(recu, out action) && (action == 1 || action == 2))
                {
                    action = Convert.ToInt32(recu);
                    choice = true;
                    break;
                }
            }
        }
        switch (action)
        {
            case 1: // restart
                NouvellePartie(); 
                break;

            case 2: // end
                affichagePendu.AfficherMessage("|Merci d'avoir joué !|", ConsoleColor.Yellow);
                System.Threading.Thread.Sleep(1000); // latence
                Environment.Exit(0);
                break;
        }
    }
}