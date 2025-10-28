import 'package:flutter/material.dart';
import 'package:mobil_cds49/models/score.dart';
import 'package:mobil_cds49/services/sqflite/score_gestione/score_bdd.dart';
import 'package:mobil_cds49/widgets/scoresListeview.dart';

class scoreApp extends StatefulWidget {
  const scoreApp({super.key});

  @override
  State<scoreApp> createState() => _scoreAppState();
}

class _scoreAppState extends State<scoreApp> {
  int score = 0;
  int nbQuestions = 0;
  int scale = 0;
  List<Score> scoresListe = [];
  void initState() {
    super.initState();
    _loadScores();
  }

  Future<void> _loadScores() async {
    // Charger depuis votre base de données
    List<Score> loadedScore = await ScoreBDD.instance.fetchAllScores();
    setState(() {
      scoresListe = loadedScore;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Gestion des Scores'),
        backgroundColor: Colors.blue,
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          children: <Widget>[
            // Formulaire d'ajout de score
            Card(
              elevation: 3,
              child: Padding(
                padding: const EdgeInsets.all(16.0),
                child: Column(
                  children: [
                    // Ligne avec les 2 TextField
                    Row(
                      children: <Widget>[
                        // TextField Score avec Expanded
                        Expanded(
                          flex: 1,
                          child: TextField(
                            decoration: const InputDecoration(
                              labelText: 'Score',
                              border: OutlineInputBorder(),
                            ),
                            keyboardType: TextInputType.number,
                            onChanged: (value) {
                              score = int.tryParse(value) ?? 0;
                            },
                          ),
                        ),
                        const SizedBox(width: 10), // Espacement
                        // TextField Nombre de questions avec Expanded
                        Expanded(
                          flex: 2,
                          child: TextField(
                            decoration: const InputDecoration(
                              labelText: 'Nombre de questions',
                              border: OutlineInputBorder(),
                            ),
                            keyboardType: TextInputType.number,
                            onChanged: (value) {
                              nbQuestions = int.tryParse(value) ?? 0;
                            },
                          ),
                        ),
                      ],
                    ),
                    const SizedBox(height: 16),
                    // Bouton Ajouter en dessous
                    SizedBox(
                      width: double.infinity,
                      child: ElevatedButton.icon(
                        onPressed: () {
                          if (score > 0 && nbQuestions > 0) {
                            final newScore = Score(
                              dateResultat: DateTime.now(),
                              scoreObtenu: score,
                              nbQuestions: nbQuestions,
                            );
                            ScoreBDD.instance.insertScore(newScore);

                            // Afficher un message de confirmation
                            ScaffoldMessenger.of(context).showSnackBar(
                              const SnackBar(
                                content: Text('Score ajouté avec succès !'),
                                backgroundColor: Colors.green,
                                duration: Duration(seconds: 2),
                              ),
                            );

                            // Recharger la liste (forcer le setState)
                            setState(() {
                              scoresListe.insert(0, newScore);
                            });
                          } else {
                            // Afficher une erreur si les champs sont vides
                            ScaffoldMessenger.of(context).showSnackBar(
                              const SnackBar(
                                content: Text(
                                  'Veuillez remplir tous les champs',
                                ),
                                backgroundColor: Colors.red,
                                duration: Duration(seconds: 2),
                              ),
                            );
                          }
                        },
                        icon: const Icon(Icons.add),
                        label: const Text('Ajouter le score'),
                        style: ElevatedButton.styleFrom(
                          padding: const EdgeInsets.all(16),
                        ),
                      ),
                    ),
                  ],
                ),
              ),
            ),
            Card(
              elevation: 3,
              child: Padding(
                padding: const EdgeInsets.all(16.0),
                child: Column(
                  children: [
                    //combo box pour choisir l'echelle
                    Row(
                      children: [
                        const Text('Échelle: '),
                        const SizedBox(width: 20),
                        DropdownButton<int>(
                          value: scale,
                          items: const [
                            DropdownMenuItem(value: 0, child: Text('Original')),
                            DropdownMenuItem(value: 10, child: Text('Sur 10')),
                            DropdownMenuItem(value: 20, child: Text('Sur 20')),
                            DropdownMenuItem(value: 30, child: Text('Sur 30')),
                            DropdownMenuItem(value: 40, child: Text('Sur 40')),
                          ],
                          onChanged: (value) {
                            setState(() {
                              scale = value ?? 0;
                            });
                          },
                        ),
                      ],
                    ),
                  ],
                ),
              ),
            ),
            const SizedBox(height: 20),
            // Titre de la liste
            const Text(
              'Historique des scores',
              style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
            ),
            const SizedBox(height: 10),
            // Liste des scores
            Expanded(
              child: ScoresListview(scale: scale, scores: scoresListe),
            ),
          ],
        ),
      ),
    );
  }
}
