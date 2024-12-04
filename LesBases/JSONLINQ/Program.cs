using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using LesBases; // Référence à la classe Article
using System.IO;

namespace InitObjComp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Liste d'articles déjà initialisée
            List<Article> articles = new List<Article>
            {
                new Article("Pomme", 2.5, 50, Article.TypeArticle.Alimentaire),
                new Article("Savon", 3.2, 30, Article.TypeArticle.Droguerie),
                new Article("T-shirt", 15.0, 20, Article.TypeArticle.Habillement),
                new Article("Ordinateur", 800.0, 5, Article.TypeArticle.Electronique),
                new Article("Ballon", 10.0, 15, Article.TypeArticle.Loisir)
            };

            // 1. Test de la méthode d'extension AfficherTous()
            articles.AfficherTous();

            // 2. Calcul de la valeur totale du stock avec une expression lambda
            double valeurTotaleStock = articles.Sum(a => a.Prix * a.Quantite);
            Console.WriteLine($"\nValeur totale du stock de tous les articles : {valeurTotaleStock:F2} €");

            // 3. Sérialisation JSON : Exporter la liste d'articles vers un fichier JSON
            // Utilisation d'un chemin absolu spécifique pour sauvegarder le fichier dans un répertoire connu
            string jsonFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "articles.json");

            Console.WriteLine("\nExportation de la liste d'articles vers un fichier JSON...");
            try
            {
                string jsonString = JsonSerializer.Serialize(articles, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonFilePath, jsonString);
                Console.WriteLine($"Exportation réussie ! Fichier généré sur le bureau : {jsonFilePath}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'exportation : {ex.Message}");
            }

            // 4. Désérialisation JSON : Charger les articles depuis le fichier JSON
            Console.WriteLine("Chargement des articles depuis le fichier JSON...");
            try
            {
                if (File.Exists(jsonFilePath))
                {
                    string jsonString = File.ReadAllText(jsonFilePath);
                    List<Article> articlesImportes = JsonSerializer.Deserialize<List<Article>>(jsonString);

                    // Affichage des articles importés
                    Console.WriteLine("Articles importés :");
                    if (articlesImportes != null)
                    {
                        foreach (var article in articlesImportes)
                        {
                            Console.WriteLine($"Nom: {article.Nom}, Prix: {article.Prix} €, Quantité: {article.Quantite}, Type: {article.Type}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Le fichier {jsonFilePath} n'existe pas.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement : {ex.Message}");
            }
        }
    }
}