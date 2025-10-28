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
  int moyenne = 0;
  DateTime start = DateTime(2025);
  DateTime end = DateTime.now();

  String filtreDate = "Tous";
  List<Score> scoresListe = [];
  List<Score> scoreInTop3 = [];

  void initState() {
    super.initState();
    _loadScores();
  }

  Future<void> _loadScores() async {
    // Charger depuis votre base de données
    List<Score> loadedScore = await ScoreBDD.instance.fetchAllScores();
    List<Score> loadedTopScore = await ScoreBDD.instance.getTop3(start, end);

    setState(() {
      scoresListe = loadedScore;
      scoreInTop3 = loadedTopScore;
      SetMoyenne();
    });
  }

  void SetMoyenne() {
    moyenne = 0;
    int cpt = 0;
    for (Score score in scoresListe) {
      moyenne += scale == 0 ? score.getNoteOn(40) : score.getNoteOn(scale);
      cpt++;
    }
    setState(() {
      moyenne ~/= cpt;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Column(
        children: <Widget>[
          //affichage du score total moyen sur la periode et sur l'echelle choisie
          Card(
            elevation: 3,
            child: Padding(
              padding: const EdgeInsets.all(8.0),
              child: Row(
                children: [
                  //combo box pour choisir l'echelle
                  const Text('Échelle: '),
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
                        SetMoyenne();
                      });
                    },
                  ),
                  //tri par perdiode (dernier jour, semaine, mois)
                  const Text('Période : '),
                  DropdownButton<String>(
                    value: filtreDate,
                    alignment: AlignmentDirectional
                        .center, // ← Centrer tout le contenu
                    items: const [
                      DropdownMenuItem(value: 'Tous', child: Text('Tous')),
                      DropdownMenuItem(
                        value: 'Jour',
                        child: Text('Dernier jour'),
                      ),
                      DropdownMenuItem(
                        value: 'Semaine',
                        child: Text('Dernière semaine'),
                      ),
                      DropdownMenuItem(
                        value: 'Mois',
                        child: Text('Dernier mois'),
                      ),
                    ],
                    onChanged: (value) async {
                      // Filtrer les scores selon la période choisie
                      DateTime now = DateTime.now();
                      if (value == 'Jour') {
                        start = now.subtract(const Duration(days: 1));
                      } else if (value == 'Semaine') {
                        start = now.subtract(const Duration(days: 7));
                      } else if (value == 'Mois') {
                        start = DateTime(now.year, now.month - 1, now.day);
                      } else {
                        start = DateTime(2000);
                      }
                      List<Score> filteredScores = await ScoreBDD.instance
                          .getScoreOfPeriod(start, end);
                      List<Score> filteredTopScores = await ScoreBDD.instance
                          .getTop3(start, end);
                      setState(() {
                        filtreDate = value ?? "Tous";
                        scoreInTop3 = filteredTopScores;
                        scoresListe = filteredScores;
                        SetMoyenne();
                      });
                    },
                  ),
                ],
              ),
            ),
          ),
          Card(
            elevation: 3,
            child: Padding(
              padding: EdgeInsetsGeometry.all(16),
              child: Text(
                "Votre score moyen est : ${scale == 0 ? "$moyenne/40" : "$moyenne/$scale"}",
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
    );
  }
}
