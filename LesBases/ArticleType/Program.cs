using LesBases;

namespace LesBases
{
    public struct Article
    {
        // Définition de l'énumération TypeArticle directement dans la structure Article
        public enum TypeArticle
        {
            Alimentaire,
            Droguerie,
            Habillement,
            Loisir,
            Electronique
        }

        public string Nom { get; set; }
        public double Prix { get; set; }
        public int Quantite { get; set; }
        public TypeArticle Type { get; set; }  // Champ pour le type d'article

        // Constructeur modifié pour inclure le type d'article
        public Article(string nom, double prix, int quantite, TypeArticle type)
        {
            Nom = nom;
            Prix = prix;
            Quantite = quantite;
            Type = type;
        }

        // Méthode pour afficher les informations de l'article
        public void Afficher()
        {
            Console.WriteLine($"Nom: {Nom}, Prix: {Prix} €, Quantité: {Quantite}, Type: {Type}");
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

    class Program
    {
        static void Main(string[] args)
        {
            // Création de quelques articles avec des types différents
            Article article1 = new Article("Pomme", 1.2, 10, Article.TypeArticle.Alimentaire);
            Article article2 = new Article("Shampoing", 5.0, 15, Article.TypeArticle.Droguerie);
            Article article3 = new Article("T-shirt", 12.5, 5, Article.TypeArticle.Habillement);

            // Affichage des articles
            Console.WriteLine("Articles initiaux:");
            article1.Afficher();
            article2.Afficher();
            article3.Afficher();

            // Modification des quantités
            Console.WriteLine("\nModification des quantités...");
            article1.Ajouter(5);  // Ajouter 5 au stock
            article2.Retirer(5);  // Retirer 5 du stock
            article3.Ajouter(3);  // Ajouter 3 au stock

            // Affichage après modification
            Console.WriteLine("\nArticles après modification:");
            article1.Afficher();
            article2.Afficher();
            article3.Afficher();

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

                Console.Write("Entrez le type de l'article (Alimentaire, Droguerie, Habillement, Loisir, Electronique) : ");
                string typeString = Console.ReadLine();

                // Tentative de conversion du type en enum
                if (Enum.TryParse(typeString, true, out Article.TypeArticle type))
                {
                    Article nouvelArticle = new Article(nom, prix, quantite, type);
                    Console.WriteLine("\nNouvel article créé :");
                    nouvelArticle.Afficher();
                }
                else
                {
                    Console.WriteLine("Erreur : Type d'article invalide.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
        }
    }
}