using LesBases; // Importation de la structure Article depuis ArticleTypé.cs
using System;

namespace GestionArticles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création d'un tableau de trois articles
            Article[] articles = new Article[3]
            {
                new Article("Pomme", 1.2, 10, Article.TypeArticle.Alimentaire),
                new Article("Shampoing", 5.0, 15, Article.TypeArticle.Droguerie),
                new Article("T-shirt", 12.5, 5, Article.TypeArticle.Habillement)
            };

            // Affichage des articles initiaux
            Console.WriteLine("Articles initiaux :");
            foreach (var article in articles)
            {
                article.Afficher();
            }

            // Modification des quantités dans le tableau
            Console.WriteLine("\nModification des quantités...");
            articles[0].Ajouter(5);  // Ajouter 5 au stock du premier article
            articles[1].Retirer(5); // Retirer 5 du stock du deuxième article
            articles[2].Ajouter(3);  // Ajouter 3 au stock du troisième article

            // Affichage des articles après modification
            Console.WriteLine("\nArticles après modification :");
            foreach (var article in articles)
            {
                article.Afficher();
            }

            // Ajout d'un nouvel article par saisie utilisateur
            Console.WriteLine("\nCréation d'un nouvel article :");
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

                // Conversion du type en enum
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
            // Affichage final du tableau après ajout d'un nouvel article
            Console.WriteLine("\nÉtat final des articles dans le tableau :");
            AfficherTableau(articles);
        }
        // Méthode pour afficher tous les articles dans un tableau
        static void AfficherTableau(Article[] articles)
        {
            foreach (var article in articles)
            {
                article.Afficher();
            }
        }
    }
}