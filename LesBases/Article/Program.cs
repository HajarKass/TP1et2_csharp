using LesBases;

namespace LesBases
{
    public struct Article
    {
        public string Nom { get; set; }
        public double Prix { get; set; }
        public int Quantite { get; set; }

        // Constructeur
        public Article(string nom, double prix, int quantite)
        {
            Nom = nom;
            Prix = prix;
            Quantite = quantite;
        }

        // Méthode pour afficher les informations de l'article
        public void Afficher()
        {
            Console.WriteLine($"Nom: {Nom}, Prix: {Prix} €, Quantité: {Quantite}");
        }

        // Méthode pour ajouter une quantité
        public void Ajouter(int quantiteAAjouter)
        {
            if (quantiteAAjouter > 0)
            {
                Quantite += quantiteAAjouter;
            }
            else
            {
                Console.WriteLine("La quantité à ajouter doit être positive.");
            }
        }

        // Méthode pour retirer une quantité
        public void Retirer(int quantiteARetirer)
        {
            if (quantiteARetirer > 0 && quantiteARetirer <= Quantite)
            {
                Quantite -= quantiteARetirer;
            }
            else
            {
                Console.WriteLine("Quantité invalide pour retrait.");
            }
        }
    }
}
class Program
    {
        static void Main(string[] args)
        {
            // Création de quelques articles
            Article article1 = new Article("Stylo", 1.5, 10);
            Article article2 = new Article("Cahier", 2.8, 20);

            // Affichage des articles
            Console.WriteLine("Articles initiaux:");
            article1.Afficher();
            article2.Afficher();

            // Modification des quantités
            Console.WriteLine("\nModification des quantités...");
            article1.Ajouter(5);  // Ajouter 5 au stock
            article2.Retirer(10); // Retirer 10 du stock

            // Affichage après modification
            Console.WriteLine("\nArticles après modification:");
            article1.Afficher();
            article2.Afficher();

            // Création d'un nouvel article par saisie utilisateur
            Console.WriteLine("\nCréation d'un nouvel article:");
            try
            {
                Console.Write("Entrez le nom de l'article : ");
                string nom = Console.ReadLine();

                Console.Write("Entrez le prix de l'article : ");
                double prix = Convert.ToDouble(Console.ReadLine());

                Console.Write("Entrez la quantité de l'article : ");
                int quantite = Convert.ToInt32(Console.ReadLine());

                Article nouvelArticle = new Article(nom, prix, quantite);

                Console.WriteLine("\nNouvel article créé :");
                nouvelArticle.Afficher();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
        }
    }