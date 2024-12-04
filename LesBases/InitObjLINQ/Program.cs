using System;
using System.Collections.Generic;
using LesBases; // Importation du namespace de ArticleType

namespace InitObjComp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialisation de la liste d'articles
            List<Article> articles = new List<Article>
            {
                new Article("Pomme", 2.5, 50, Article.TypeArticle.Alimentaire),
                new Article("Savon", 3.2, 30, Article.TypeArticle.Droguerie),
                new Article("T-shirt", 15.0, 20, Article.TypeArticle.Habillement)
            };

            // Affichage pour vérifier les données chargées
            Console.WriteLine("Liste des articles chargés :");
            foreach (var article in articles)
            {
                Console.WriteLine($"Nom: {article.Nom}, Prix: {article.Prix:F2}€, Quantité: {article.Quantite}, Type: {article.Type}");
            }
        }
    }
}